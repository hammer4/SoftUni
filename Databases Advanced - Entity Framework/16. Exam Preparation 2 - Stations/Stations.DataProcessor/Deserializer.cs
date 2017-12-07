using System;
using Stations.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stations.Models;
using System.Linq;
using Stations.DataProcessor.Dto;
using Stations.Models.Enums;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Stations.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            var result = new List<string>();

            var objects = JsonConvert.DeserializeObject<StationDto[]>(jsonString);
            var stationsToImport = new List<Station>();

            foreach (var o in objects)
            {
                if (o.Town == null)
                {
                    o.Town = o.Name;
                }

                if (o.Name == null || o.Name.Length > 50 || o.Town.Length > 50 || stationsToImport.Any(s => s.Name == o.Name))
                {
                    result.Add(FailureMessage);
                    continue;
                }

                stationsToImport.Add(new Station { Name = o.Name, Town = o.Town });
                result.Add(String.Format(SuccessMessage, o.Name));
            }

            context.Stations.AddRange(stationsToImport);
            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var result = new List<string>();
            var classesToImport = new List<SeatingClass>();

            var objects = JsonConvert.DeserializeAnonymousType(jsonString, new[] { new { Name = String.Empty, Abbreviation = String.Empty } });

            foreach (var o in objects)
            {
                if (classesToImport.Any(c => c.Name == o.Name) || classesToImport.Any(c => c.Abbreviation == o.Abbreviation) || o.Abbreviation == null || o.Name == null || o.Name.Length > 30 || o.Abbreviation.Length != 2)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                classesToImport.Add(new SeatingClass { Name = o.Name, Abbreviation = o.Abbreviation });
                result.Add(String.Format(SuccessMessage, o.Name));
            }

            context.SeatingClasses.AddRange(classesToImport);
            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var result = new List<string>();

            var trainSeats = new List<TrainSeat>();
            var trains = new List<Train>();

            var classes = context.SeatingClasses.ToArray();

            var objects = JsonConvert.DeserializeObject<TrainDto[]>(jsonString);

            foreach (var o in objects)
            {
                if (o.TrainNumber == null || trains.Any(t => t.TrainNumber == o.TrainNumber) || o.TrainNumber.Length > 10)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var type = o.Type == null ? TrainType.HighSpeed : (TrainType)Enum.Parse(typeof(TrainType), o.Type);

                var train = new Train { TrainNumber = o.TrainNumber, Type = type };

                if(o.Seats != null)
                {
                    if (!o.Seats.All(s => s.Abbreviation != null && s.Name != null && s.Quantity != null && classes.Any(c => c.Name == s.Name && c.Abbreviation == s.Abbreviation) && s.Quantity > 0))
                    {
                        result.Add(FailureMessage);
                        continue;
                    }

                    foreach(var s in o.Seats)
                    {
                        var classe = classes.SingleOrDefault(c => c.Name == s.Name && c.Abbreviation == s.Abbreviation);

                        trainSeats.Add(new TrainSeat { Quantity = (int)s.Quantity, SeatingClass = classe, Train = train });
                    }
                }

                trains.Add(train);
                result.Add(String.Format(SuccessMessage, o.TrainNumber));
            }

            context.Trains.AddRange(trains);
            context.TrainSeats.AddRange(trainSeats);
            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var result = new List<string>();

            var validTrips = new List<Trip>();
            var objects = JsonConvert.DeserializeObject<TripDto[]>(jsonString);

            foreach(var o in objects)
            {
                var originStation = context.Stations
                    .SingleOrDefault(s => s.Name == o.OriginStation);

                var destinationStation = context.Stations
                    .SingleOrDefault(s => s.Name == o.DestinationStation);

                if(originStation == null || destinationStation == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                DateTime? departureTime = null;
                if(o.DepartureTime != null)
                {
                    departureTime = DateTime.ParseExact(o.DepartureTime, "dd/MM/yyyy HH:mm", null);
                }

                DateTime? arrivalTime = null;
                if (o.ArrivalTime != null)
                {
                    arrivalTime = DateTime.ParseExact(o.ArrivalTime, "dd/MM/yyyy HH:mm", null);
                }

                if(departureTime == null || arrivalTime == null || arrivalTime < departureTime)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var train = context.Trains
                    .SingleOrDefault(t => t.TrainNumber == o.Train);

                if(train == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var status = o.Status == null ? TripStatus.OnTime : (TripStatus)Enum.Parse(typeof(TripStatus), o.Status);

                TimeSpan? difference = null;

                if(o.TimeDifference != null)
                {
                    difference = TimeSpan.ParseExact(o.TimeDifference, "hh\\:mm", null);
                }

                validTrips.Add(new Trip { ArrivalTime = (DateTime)arrivalTime, DepartureTime = (DateTime)departureTime, DestinationStation = destinationStation, OriginStation = originStation, Status = status, Train = train, TimeDifference = difference });

                result.Add($"Trip from {originStation.Name} to {destinationStation.Name} imported.");
            }

            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            return String.Join(Environment.NewLine, result);
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var result = new List<string>();
            var validCards = new List<CustomerCard>();

            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            foreach(var c in elements)
            {
                var name = c.Element("Name")?.Value;
                var ageStr = c.Element("Age")?.Value;
                var type = c.Element("CardType")?.Value;

                if(name == null || ageStr == null || name.Length > 128)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                int age = int.Parse(ageStr);

                if(age < 0 || age > 120)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                CardType cardType = type == null ? CardType.Normal : (CardType)Enum.Parse(typeof(CardType), type);

                validCards.Add(new CustomerCard { Age = age, Name = name, Type = cardType });
                result.Add(String.Format(SuccessMessage, name));
            }

            context.Cards.AddRange(validCards);
            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var result = new List<string>();
            var validTickets = new List<Ticket>();

            var xDoc = XDocument.Parse(xmlString);
            var elements = xDoc.Root.Elements();

            foreach (var ticket in elements)
            {
                var priceAttr = ticket.Attribute("price")?.Value;
                var seatAttr = ticket.Attribute("seat")?.Value;

                if (priceAttr == null || seatAttr == null || seatAttr.Length > 8)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var tripEl = ticket.Element("Trip");

                var origin = tripEl.Element("OriginStation")?.Value;
                var destination = tripEl.Element("DestinationStation")?.Value;
                var timeStr = tripEl.Element("DepartureTime")?.Value;

                if (origin == null || destination == null || timeStr == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var time = DateTime.ParseExact(timeStr, "dd/MM/yyyy HH:mm", null);

                var originStation = context.Stations
                    .SingleOrDefault(s => s.Name == origin);

                var destinationStation = context.Stations
                    .SingleOrDefault(s => s.Name == destination);

                if (originStation == null || destinationStation == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var trip = context.Trips
                    .Include(t => t.Train)
                    .SingleOrDefault(t => t.OriginStation == originStation && t.DestinationStation == destinationStation && t.DepartureTime == time);

                if(trip == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var train = trip.Train;

                var abbreviation = seatAttr.Substring(0, 2);
                int number;
                var isNumber = int.TryParse(seatAttr.Substring(2), out number);

                if (!isNumber || number <= 0)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var classe = context.SeatingClasses
                    .SingleOrDefault(sc => sc.Abbreviation == abbreviation);

                if(classe == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var trainSeat = context.TrainSeats
                    .SingleOrDefault(ts => ts.Train == train && ts.SeatingClass == classe);

                if(trainSeat == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                if(trainSeat.Quantity < number)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                var cardEl = ticket.Element("Card");
                if (cardEl != null)
                {
                    var name = cardEl.Attribute("Name")?.Value;

                    card = context.Cards
                        .SingleOrDefault(c => c.Name == name);

                    if(card == null)
                    {
                        result.Add(FailureMessage);
                        continue;
                    }
                }

                decimal price = decimal.Parse(priceAttr);
                if(price < 0)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                validTickets.Add(new Ticket { CustomerCard = card, Price = price, SeatingPlace = seatAttr, Trip = trip });
                result.Add($"Ticket from {origin} to {destination} departing at {time:dd/MM/yyyy HH:mm} imported.");
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }
    }
}