namespace P01_HospitalDatabase.Generators
{
    using System;

    public class AddressGenerator
    {
        private static Random rnd = new Random();

        private static string[] townNames =
        {
            "Kinecardine",
            "Whitebridge ",
            "Nuxvar",
            "Laencaster",
            "Lowestoft",
            "Brickelwhyte ",
            "Skegness",
            "Tenby",
            "Dalmellington",
            "Ormkirk",
        };
        //private static string[] townNames = File.ReadAllLines("<INSERT DIR HERE>");
        private static string[] streetNames = 
        {
            "Somerset Drive",
            "Prospect Street",
            "Highland Avenue",
            "Windsor Court",
            "College Avenue",
            "Green Street",
            "Colonial Avenue",
            "Elm Avenue",
            "Durham Road",
            "Rose Street",
            "6th Street North",
            "Brandywine Drive",
            "Madison Avenue",
            "Route 10",
            "Main Street East",
        };
        //private static string[] streetNames = File.ReadAllLines("<INSERT DIR HERE>");

        internal static string NewAddress()
        {
            string townName = townNames[rnd.Next(townNames.Length)];
            string streetName = streetNames[rnd.Next(streetNames.Length)];
            int number = rnd.Next(1, 100);

            return $"{townName}, {streetName} {number}";
        }
    }
}
