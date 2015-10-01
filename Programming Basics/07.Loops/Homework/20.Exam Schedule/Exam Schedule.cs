using System;

class ExamSchedule
{
    static void Main()
    {
        int hour = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        string timeOfDay = Console.ReadLine();
        if (timeOfDay == "AM")
            if (hour == 12)
            {
                hour = 0;
            }
        if (timeOfDay == "PM")
            if (hour < 12)
                hour += 12;
        DateTime time = new DateTime(2000,12,20,hour,minutes,0);
        int examHours = int.Parse(Console.ReadLine());
        int examMinutes = int.Parse(Console.ReadLine());
        time = time.AddHours(examHours);
        time = time.AddMinutes(examMinutes);
        Console.WriteLine("{0:hh:mm:tt}", time);
        
    }
}