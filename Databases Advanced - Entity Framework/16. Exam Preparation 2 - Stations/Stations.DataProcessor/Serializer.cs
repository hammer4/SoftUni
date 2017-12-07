using System;
using Stations.Data;
using System.Linq;
using Stations.Models.Enums;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Stations.DataProcessor
{
	public class Serializer
	{
		public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
		{
            var date = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", null);

            var trains = context.Trains
                .Where(t => t.Trips.Any(tr => tr.Status == TripStatus.Delayed && tr.DepartureTime <= date))
                .Select(t => new
                {
                    t.TrainNumber,
                    DelayedTimes = t.Trips
                        .Where(tr => tr.Status == TripStatus.Delayed && tr.DepartureTime <= date)
                        .Count(),
                    MaxDelayedTime = t.Trips
                        .Where(tr => tr.Status == TripStatus.Delayed)
                        .OrderByDescending(tr => tr.TimeDifference)
                        .Select(tr => tr.TimeDifference)
                        .First()
                })
                .OrderByDescending(t => t.DelayedTimes)
                .ThenByDescending(t => t.MaxDelayedTime)
                .ThenBy(t => t.TrainNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(trains, Formatting.Indented);

            return json;
		}

		public static string ExportCardsTicket(StationsDbContext context, string cardType)
		{
            var cards = context.Cards
                .Where(c => (CardType)Enum.Parse(typeof(CardType), cardType) == c.Type && c.BoughtTickets.Count > 0)
                .Select(c => new
                {
                    Name = c.Name,
                    Type = cardType,
                    Tickets = c.BoughtTickets
                        .Select(t => new
                        {
                            OriginStation = t.Trip.OriginStation.Name,
                            DestinationStation = t.Trip.DestinationStation.Name,
                            DepartureTime = t.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm")
                        })
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var xDoc = new XDocument();

            xDoc.Add(new XElement("Cards"));

            foreach(var c in cards)
            {
                var card = new XElement("Card", new XAttribute("name", c.Name), new XAttribute("type", c.Type));
                var tickets = new XElement("Tickets");

                foreach(var t in c.Tickets)
                {
                    var ticket = new XElement("Ticket");

                    ticket.Add(
                        new XElement("OriginStation", t.OriginStation),
                        new XElement("DestinationStation", t.DestinationStation),
                        new XElement("DepartureTime", t.DepartureTime)
                        );

                    tickets.Add(ticket);
                }

                card.Add(tickets);
                xDoc.Element("Cards").Add(card);
            }

            return xDoc.ToString();
		}
	}
}