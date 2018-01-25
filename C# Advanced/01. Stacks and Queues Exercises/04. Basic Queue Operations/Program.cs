using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int enqueueCount = input[0];
            int dequeueCount = input[1];
            int item = input[2];

            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(array);

            for(int i=0; i<dequeueCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(item))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
