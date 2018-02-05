using System;
using System.Linq;

namespace _06._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            int number = int.Parse(Console.ReadLine());

            Predicate<int> filter = x => x % number != 0;
            Func<int, bool> filterFunc = x => filter(x);

            array = array
                .Where(filterFunc);

            Console.WriteLine(String.Join(" ", array.Reverse()));
        }
    }
}
