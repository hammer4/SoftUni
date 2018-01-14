using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var queue = new Queue<int>();
        queue.Enqueue(int.Parse(Console.ReadLine()));
        List<int> result = new List<int>();

        while(result.Count < 50)
        {
            int current = queue.Dequeue();
            result.Add(current);
            queue.Enqueue(current + 1);
            queue.Enqueue(current * 2 + 1);
            queue.Enqueue(current + 2);
        }

        Console.WriteLine(String.Join(", ", result));
    }
}
