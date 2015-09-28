using System;

public class ReadingPrintingStrings
{
    public static void Main()
    {
        string[] towns =
        {
            "Sofia", 
            "Varna", 
            "Plovdiv", 
            "Pleven", 
            "Bourgas", 
            "Rousse", 
            "Stara Zagora", 
            "Veliko Tarnovo", 
            "Yambol", 
            "Sliven"
        };

        string firstTown = towns[0];

        for (int i = 1; i < towns.Length; i++)
        {
            string currentTown = towns[i];

            if (string.Compare(currentTown, firstTown) < 0)
            {
                firstTown = currentTown;
            }
        }

        Console.WriteLine("First town: {0}", firstTown);
    }
}
