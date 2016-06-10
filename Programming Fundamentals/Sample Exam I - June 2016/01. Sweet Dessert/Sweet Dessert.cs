using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sweet_Desert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal ammountOfCash = decimal.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            decimal priceOfBananas = decimal.Parse(Console.ReadLine());
            decimal priceOfEggs = decimal.Parse(Console.ReadLine());
            decimal priceOfBerries = decimal.Parse(Console.ReadLine());

            int numberOfPortions = (int)Math.Ceiling((decimal)numberOfGuests / 6);
            decimal pricePerPortion = 2 * priceOfBananas + 4 * priceOfEggs + (decimal)0.2 * priceOfBerries;
            decimal priceOfProducts = pricePerPortion * numberOfPortions;

            if (ammountOfCash >= priceOfProducts)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", priceOfProducts);
            }
            else
            {
                decimal moneyNeeded = priceOfProducts - ammountOfCash;
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", moneyNeeded);
            }
        }
    }
}
