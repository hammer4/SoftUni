using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long first = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var result = new List<long>();

            queue.Enqueue(first);
            result.Add(first);

            while(result.Count < 50)
            {
                long current = queue.Dequeue();
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);

                result.Add(current + 1);
                result.Add(2 * current + 1);
                result.Add(current + 2);
            }

            Console.WriteLine(String.Join(" ", result.Take(50)));
        }
    }
}
