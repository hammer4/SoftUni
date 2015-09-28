using System;
using System.Collections.Generic;
using System.Linq;

class SortedSubsetSums
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] integers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();

        List<List<int>> list = new List<List<int>>();
        for (int mask = 1; mask < Math.Pow(2, integers.Length); mask++)
        {
            List<int> combination = new List<int>();
            for (int i = 0; i < integers.Length; i++)
            {
                if ((mask >> i & 1) == 1)
                {
                    combination.Add(integers[i]);
                }
            }
            list.Add(combination);
        }

        foreach (List<int> list1 in list)
        {
            list1.Sort();
        }

        List<List<int>> ordered = new List<List<int>>(list.OrderBy(x => x.Count).ThenBy(x => x.First()));

        bool existEqualSubset = false;
        foreach (List<int> combination in ordered)
        {
            int sum = combination.Sum(x => Convert.ToInt32(x));
            if (sum == number)
            {
                Console.WriteLine(String.Join(" + ", combination) + " = " + number);
                existEqualSubset = true;
            }
        }
        if (!existEqualSubset)
        {
            Console.WriteLine("No matching subsets.");
        }
    }
}