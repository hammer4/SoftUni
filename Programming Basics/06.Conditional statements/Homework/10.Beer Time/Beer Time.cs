using System;

class BeerTime
{
    static void Main()
    {
        Console.WriteLine("Enter a time in the format: hh:mm tt");
        string input = Console.ReadLine();
        DateTime beer;
        bool valid = DateTime.TryParse(input, out beer);
        if (valid)
        {
            if (beer.Hour >= 13 || beer.Hour < 3)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("invalid time");
        }
    }
}
