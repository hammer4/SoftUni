using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Beer_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while(command != "End")
            {
                int[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                BeerCounter.BuyBeer(tokens[0]);
                BeerCounter.DrinkBeer(tokens[1]);

                command = Console.ReadLine();
            }

            Console.WriteLine("{0} {1}", BeerCounter.beerInStock, BeerCounter.beersDrankCount);
        }
    }
}
