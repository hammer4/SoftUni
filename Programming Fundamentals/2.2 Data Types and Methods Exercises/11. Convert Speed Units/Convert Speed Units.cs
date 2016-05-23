using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            decimal distanceInMiles = distanceInMeters / 1609m;
            int totalSeconds = hours * 3600 + minutes * 60 + seconds;

            float mps = (float)distanceInMeters / totalSeconds;
            float kmh = ((float)distanceInMeters / 1000) / ((float)totalSeconds / 3600);
            float mph = ((float)distanceInMiles) / ((float)totalSeconds / 3600);

            Console.WriteLine(mps);
            Console.WriteLine(kmh);
            Console.WriteLine(mph);
        }
    }
}
