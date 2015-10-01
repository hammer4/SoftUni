using System;

class NumberAsDayOfWeek
{
    static void Main()
    {
        Console.Write("Enter a number (1-7): ");
        int day=0;
        try
        {
            day = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("not valid");
            return;
        }

        switch (day)
        {
            case 1: Console.WriteLine("Monday"); break;
            case 2: Console.WriteLine("Tuesday"); break;
            case 3: Console.WriteLine("Wednesday"); break;
            case 4: Console.WriteLine("Thursday"); break;
            case 5: Console.WriteLine("Friday"); break;
            case 6: Console.WriteLine("Saturday"); break;
            case 7: Console.WriteLine("Sunday"); break;
            default: Console.WriteLine("not valid"); break;
        }
    }
}
