using System;

public class SplittingStrings
{
    public static void Main()
    {
        const string ListOfBeers = "Amstel, Zagorka, Tuborg, Becks.";

        string[] beers = ListOfBeers.Split(' ', ',', '.');

        // string[] beers = ListOfBeers.Split(
        //    new[] { ' ', ',', '.' },
        //    StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Available beers:");
        foreach (string beer in beers)
        {
            // Two sequential separators in the input cause
            // presence of empty elements in the result
            if (beer != string.Empty)
            {
                Console.WriteLine(beer);
            }
        }
    }
}