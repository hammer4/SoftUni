using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x%2 == 0;

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string condition = Console.ReadLine();

            List<int> result = new List<int>();

            Enumerable.Range(input[0], input[1] - input[0] + 1)
                .Where(x => condition == "even" ? isEven(x) : !isEven(x))
                .ToList()
                .ForEach(result.Add);

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
