using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var stack = new Stack<int>(numbers);
            Console.WriteLine(String.Join(" ", stack.ToArray()));
        }
    }
}
