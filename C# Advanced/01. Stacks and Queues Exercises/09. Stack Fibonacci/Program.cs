using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for(int i=2; i<=count; i++)
            {
                long second = stack.Pop();
                long first = stack.Pop();
                stack.Push(second);
                stack.Push(first + second);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
