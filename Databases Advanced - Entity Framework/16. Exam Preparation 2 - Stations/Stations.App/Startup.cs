using System;
using System.IO;
using AutoMapper;
using Stations.Data;

namespace Stations.App
{
	public class Startup
	{
		public static void Main(string[] args)
		{
			var context = new StationsDbContext();
            ResetDatabase(context);

            Console.WriteLine("Database Reset.");

            Mapper.Initialize(cfg => cfg.AddProfile<StationsProfile>());

            ImportEntities(context);
            ExportEntities(context);
        }

		private static void ImportEntities(StationsDbContext context, string baseDir = @"..\Datasets\")
		{
			const string exportDir = "./ImportResults/";

            var stations = DataProcessor.Deserializer.ImportStations(context, File.ReadAllText(baseDir + "stations.json"));
            PrintAndExportEntityToFile(stations, exportDir + "Stations.txt");

            var classes = DataProcessor.Deserializer.ImportClasses(context, File.ReadAllText(baseDir + "classes.json"));
            PrintAndExportEntityToFile(classes, exportDir + "Classes.txt");

            var trains = DataProcessor.Deserializer.ImportTrains(context, File.ReadAllText(baseDir + "trains.json"));
            PrintAndExportEntityToFile(trains, exportDir + "Trains.txt");

            var trips = DataProcessor.Deserializer.ImportTrips(context, File.ReadAllText(baseDir + "trips.json"));
            PrintAndExportEntityToFile(trips, exportDir + "Trips.txt");

            var cards = DataProcessor.Deserializer.ImportCards(context, File.ReadAllText(baseDir + "cards.xml"));
            PrintAndExportEntityToFile(cards, exportDir + "Cards.txt");

            var tickets = DataProcessor.Deserializer.ImportTickets(context, File.ReadAllText(baseDir + "tickets.xml"));
            PrintAndExportEntityToFile(tickets, exportDir + "Tickets.txt");
        }

		private static void ExportEntities(StationsDbContext context)
		{
			const string exportDir = "./ImportResults/";

            var jsonOutput = DataProcessor.Serializer.ExportDelayedTrains(context, "01/01/2017");
            Console.WriteLine(jsonOutput);
            File.WriteAllText(exportDir + "DelayedTrains.json", jsonOutput);

            var xmlOutput = DataProcessor.Serializer.ExportCardsTicket(context, "Debilitated");
            Console.WriteLine(xmlOutput);
            File.WriteAllText(exportDir + "CardsTicket.xml", xmlOutput);
        }

		private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
		{
			Console.WriteLine(entityOutput);
			File.WriteAllText(outputPath, entityOutput.TrimEnd());
		}

		private static void ResetDatabase(StationsDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}
	}
}