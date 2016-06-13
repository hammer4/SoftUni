using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Softuni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            decimal totalPrice = 0m;

            for(int i=0; i<ordersCount; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int days = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                long capsulesCount = long.Parse(Console.ReadLine());

                decimal orderPrice = capsulesCount * days * pricePerCapsule;
                Console.WriteLine("The price for the coffee is: ${0:F2}", orderPrice);
                totalPrice += orderPrice;
            }

            Console.WriteLine("Total: ${0:F2}", totalPrice);
        }
    }
}
