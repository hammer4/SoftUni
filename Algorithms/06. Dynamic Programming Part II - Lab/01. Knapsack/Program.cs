using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int capacity = int.Parse(Console.ReadLine());

        string command;

        List<Item> itemsList = new List<Item>();
        while ((command = Console.ReadLine()) != "end")
        {
            var tokens = command.Split();

            itemsList.Add(new Item { Name = tokens[0], Weight = int.Parse(tokens[1]), Value = int.Parse(tokens[2]) });
        }

        Item[] items = itemsList.OrderBy(i => i.Name).ToArray();

        var result = FillKnapsack(items, capacity);

        Console.WriteLine($"Total Weight: {result.Sum(i => i.Weight)}");
        Console.WriteLine($"Total Value: {result.Sum(i => i.Value)}");
        Console.WriteLine(String.Join(Environment.NewLine, result.Select(i => i.Name)));
    }

    static List<Item> FillKnapsack(Item[] items, int capacity)
    {
        var maxValues = new int[items.Length + 1, capacity + 1];
        var itemIncluded = new bool[items.Length + 1, capacity + 1];

        for (int i = 0; i < items.Length; i++)
        {
            for (int currCapacity = 1; currCapacity <= capacity; currCapacity++)
            {
                if (items[i].Weight > currCapacity)
                {
                    continue;
                }

                int valueIncluded = items[i].Value + maxValues[i, currCapacity - items[i].Weight];
                if (valueIncluded > maxValues[i, currCapacity])
                {
                    maxValues[i + 1, currCapacity] = valueIncluded;
                    itemIncluded[i + 1, currCapacity] = true;
                }
                else
                {
                    maxValues[i + 1, currCapacity] = maxValues[i, currCapacity];
                }
            }
        }

        List<Item> takenItems = new List<Item>();
        for (int i = items.Length; i > 0; i--)
        {
            if (!itemIncluded[i, capacity]) continue;

            Item item = items[i - 1];
            takenItems.Add(item);

            capacity -= item.Weight;
        }

        takenItems.Reverse();
        return takenItems;
    }

    private class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }
}
