using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftUni_Airline
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfFlights = int.Parse(Console.ReadLine());
            decimal overallProfit = 0m;

            for(int i=0; i<countOfFlights; i++)
            {
                int adultPassengersCount = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                int youthPassengersCount = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                decimal ticketIncome = adultPassengersCount * adultTicketPrice + youthPassengersCount * youthTicketPrice;
                decimal fuelExpenses = fuelConsumptionPerHour * fuelPricePerHour * flightDuration;

                decimal flightProfit = ticketIncome - fuelExpenses;

                if(flightProfit >= 0)
                {
                    Console.WriteLine("You are ahead with {0:F3}$.", flightProfit);
                }
                else
                {
                    Console.WriteLine("We've got to sell more tickets! We've lost {0:F3}$.", flightProfit);
                }

                overallProfit += flightProfit;
            }

            Console.WriteLine("Overall profit -> {0:F3}$.", overallProfit);
            Console.WriteLine("Average profit -> {0:F3}$.", overallProfit/countOfFlights);
        }
    }
}
