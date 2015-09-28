using System;

class DataValidation
{
	static void Main()
	{
		Console.WriteLine("What time is it?");
		
		Console.Write("Hours: ");
		int hours = int.Parse(Console.ReadLine());

		Console.Write("Minutes: ");
		int minutes = int.Parse(Console.ReadLine());

		bool isValidTime = ValidateHours(hours) && ValidateMinutes(minutes);
		if (isValidTime)
		{
			Console.WriteLine("The time is {0}:{1} now.", hours, minutes);
		}
		else
		{
			Console.WriteLine("Incorrect time!");
		}
	}

	static bool ValidateMinutes(int minutes)
	{
		bool result = (minutes >= 0) && (minutes <= 59);
		return result;
	}

	static bool ValidateHours(int hours)
	{
		bool result = (hours >= 0) && (hours <= 24);
		return result;
	}
}
