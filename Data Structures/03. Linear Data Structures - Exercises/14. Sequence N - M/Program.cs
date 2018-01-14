using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    class Item
    {
        public Item(int value, Item prevItem)
        {
            this.Value = value;
            this.PrevItem = prevItem;
        }

        public int Value { get; private set; }
        public Item PrevItem { get; private set; }
    }

    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = input[0];
        var m = input[1];

        var result = new List<int>();

        var queue = new Queue<Item>();

        queue.Enqueue(new Item(n, null));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Value < m)
            {
                queue.Enqueue(new Item(current.Value + 1, current));
                queue.Enqueue(new Item(current.Value + 2, current));
                queue.Enqueue(new Item(current.Value * 2, current));
            }

            if (current.Value == m)
            {
                while (current != null)
                {
                    result.Add(current.Value);
                    current = current.PrevItem;
                }
                result.Reverse();

                Console.WriteLine(String.Join(" -> ", result));
                return;
            }
        }
    }
}