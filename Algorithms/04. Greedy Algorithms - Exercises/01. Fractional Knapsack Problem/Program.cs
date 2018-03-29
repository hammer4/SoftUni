using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        decimal capacity = decimal.Parse(Console.ReadLine().Split().Last());
        int count = int.Parse(Console.ReadLine().Split().Last());

        decimal price = 0;
        List<Item> items = new List<Item>();

        for (int i = 0; i < count; i++)
        {
            var input = Console.ReadLine().Split();

            items.Add(new Item { Price = decimal.Parse(input.First()), Weight = decimal.Parse(input.Last()) });
        }

        var sortedItems = items.OrderByDescending(i => i.Price / i.Weight).ToList();

        while (capacity > 0 && sortedItems.Count > 0)
        {
            var currentItem = sortedItems.First();

            decimal fraction = capacity >= currentItem.Weight ? 1 : capacity / currentItem.Weight;

            Console.WriteLine($"Take {(fraction == 1 ? (fraction * 100).ToString() : (fraction * 100).ToString("F2"))}% of item with price {currentItem.Price:F2} and weight {currentItem.Weight:F2}");
            capacity -= fraction * currentItem.Weight;
            price += fraction * currentItem.Price;

            sortedItems.Remove(currentItem);
        }

        Console.WriteLine($"Total price: {price:F2}");
    }

    private class Item
    {
        public decimal Price { get; set; }

        public decimal Weight { get; set; }
    }
}