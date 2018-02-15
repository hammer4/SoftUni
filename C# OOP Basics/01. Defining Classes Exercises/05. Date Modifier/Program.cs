using System;

class Program
{
    static void Main(string[] args)
    {
        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();

        DateModifier dateModifier = new DateModifier();

        Console.WriteLine(dateModifier.CalculateDifference(date1, date2));
    }
}