using System;

class Months
{
	static void SayMonth(int month)
	{
		string[] monthNames = new string[]
        { 
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };
        string monthName = monthNames[month - 1];
		Console.Write(monthName);
	}

	static void SayPeriod(int startMonth, int endMonth)
	{
		int period = endMonth - startMonth;
		if (period < 0)
		{
			period = period + 12; 
			// From December to January the
			// period is 1 month, not -11 !
		}

		Console.Write("There are {0} months from ", period);
		SayMonth(startMonth);
		Console.Write(" to ");
		SayMonth(endMonth);
		Console.WriteLine(".");
	}

	static void Main()
	{
		Console.Write("First month (1-12): ");
		int firstMonth = int.Parse(Console.ReadLine());

		Console.Write("Second month (1-12): ");
		int secondMonth = int.Parse(Console.ReadLine());

		SayPeriod(firstMonth, secondMonth);
	}
}

