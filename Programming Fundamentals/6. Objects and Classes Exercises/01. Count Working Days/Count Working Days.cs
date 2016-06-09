using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Working_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            input = Console.ReadLine();
            DateTime endDate = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int workingDays = 0;
            
            for(DateTime i = startDate; i<=endDate; i = i.AddDays(1))
            {
                if(i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday && !(i.Month == 1 && i.Day == 1) && !(i.Month == 3 && i.Day == 3) && !(i.Month == 5 && i.Day == 1) && !(i.Month == 5 && i.Day == 6) && !(i.Month == 5 && i.Day == 24) && !(i.Month == 9 && i.Day == 6) && !(i.Month == 9 && i.Day == 22) && !(i.Month == 11 && i.Day == 1) && !(i.Month == 12 && i.Day == 24) && !(i.Month == 12 && i.Day == 25) && !(i.Month == 12 && i.Day == 26))
                {
                    workingDays++;
                }
            }

            Console.WriteLine(workingDays);
        }
    }
}
