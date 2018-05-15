using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static StringBuilder builder = new StringBuilder();

    static void Main(string[] args)
    {
        int fuel = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        List<Item> items = new List<Item>();

        while(input != "End")
        {
            string[] tokens = input.Split(',').Select(s => s.Trim()).ToArray();
            Item item = new Item(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]));
            items.Add(item);
            input = Console.ReadLine();
        }

        List<Item> total = new List<Item>();
        total = Fill(items.ToArray(), fuel);

        total.Reverse();

        builder.AppendLine(String.Join(" -> ", total.Select(i => i.Name)))
            .AppendLine($"Total pokemons caught -> {total.Sum(i => i.Count)}")
            .AppendLine($"Total car damage -> {total.Sum(i => i.Damage)}")
            .Append($"Fuel Left -> {fuel - total.Sum(i => i.Length)}");

        Console.WriteLine(builder.ToString());
    }

    private static List<Item> Fill(Item[] items, int fuel)
    {
        int[,] values = new int[items.Length + 1, fuel + 1];
        bool[,] isItemIncluded = new bool[items.Length + 1, fuel + 1];
        List<Item> itemsTaken = new List<Item>();

        for(int itemIndex =0; itemIndex < items.Length; itemIndex++)
        {
            int row = itemIndex + 1;
            Item item = items[itemIndex];

            for(int c = 1; c <= fuel; c++)
            {
                int excludedValue = values[row - 1, c];
                int includedValue = 0;

                if(item.Length <= c)
                {
                    includedValue = (item.Count * 10 - item.Damage) + values[row - 1, c - item.Length];
                }

                if(includedValue > excludedValue)
                {
                    values[row, c] = includedValue;
                    isItemIncluded[row, c] = true;
                }
                else
                {
                    values[row, c] = excludedValue;
                }
            }
        }

        int tempCap = fuel;

        for(int i = items.Length; i > 0; i--)
        {
            if(!isItemIncluded[i, tempCap])
            {
                continue;
            }

            Item item = items[i - 1];
            itemsTaken.Add(item);
            tempCap -= item.Length;
        }

        return itemsTaken;
    }
}

class Item
{
    public Item(string name, int damage, int count, int length)
    {
        this.Name = name;
        this.Damage = damage;
        this.Count = count;
        this.Length = length;
    }

    public string Name { get; set; }

    public int Damage { get; set; }

    public int Count { get; set; }

    public int Length { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
}