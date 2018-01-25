using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int pushCount = input[0];
            int popCount = input[1];
            int element = input[2];

            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for(int i = 0; i < pushCount; i++)
            {
                stack.Push(elements[i]);
            }

            for(int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
