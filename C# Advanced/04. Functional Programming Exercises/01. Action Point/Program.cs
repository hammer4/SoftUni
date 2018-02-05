using System;
using System.Linq;

namespace _01._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);
        }
    }
}
