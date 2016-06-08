using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sales_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfSales = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[countOfSales];

            for (int i=0; i<countOfSales; i++)
            {
                sales[i] = ReadSale(Console.ReadLine());
            }

            SortedDictionary<string, decimal> dictionary = new SortedDictionary<string, decimal>();

            foreach(Sale sale in sales)
            {
                if(dictionary.ContainsKey(sale.Town))
                {
                    dictionary[sale.Town] += sale.Price * sale.Quantity;
                }
                else
                {
                    dictionary[sale.Town] = sale.Price * sale.Quantity;
                }
            }

            foreach(var pair in dictionary)
            {
                Console.WriteLine("{0} -> {1:F2}", pair.Key, pair.Value);
            }
        }

        static Sale ReadSale(string input)
        {
            string[] tokens = input.Split(' ');
            return new Sale { Town = tokens[0], Product = tokens[1], Price = decimal.Parse(tokens[2]), Quantity = decimal.Parse(tokens[3]) };
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
