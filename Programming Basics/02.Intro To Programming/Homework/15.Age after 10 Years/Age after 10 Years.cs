using System;
using System.Globalization;

class AgeAfter10Years
{
    static void Main()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        Console.Write("Enter your birthday in format dd.MM.yyyy: ");
        DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", provider);
        DateTime dateNow = DateTime.Now;
        TimeSpan span = dateNow.Subtract(birthday);
        Console.WriteLine("Now: " + (int)(span.TotalDays / 365.25));
        Console.WriteLine("After 10 years: " + (int)(span.TotalDays / 365.25 + 10));
    }
}