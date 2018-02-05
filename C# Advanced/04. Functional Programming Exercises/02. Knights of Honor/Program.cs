using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> appendSir = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(appendSir);
        }
    }
}
