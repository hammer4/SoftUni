using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Beer_Counter
{
    public class BeerCounter
    {
        public static int beerInStock = 0;
        public static int beersDrankCount = 0;

        public static void BuyBeer(int bottlesCount)
        {
            beerInStock += bottlesCount;
        }

        public static void DrinkBeer(int bottlesCount)
        {
            beersDrankCount += bottlesCount;
            beerInStock -= bottlesCount;
        }
    }
}
