using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSums
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] integers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();        

        List<List<int>> list = new List<List<int>>();
        for (int mask = 1; mask < Math.Pow(2, integers.Length); mask++)
        {
            List<int> combination = new List<int>();
            for(int i=0; i<integers.Length; i++)
            {
                if ((mask >> i & 1) == 1)
                {
                    combination.Add(integers[i]);
                }
            }
            list.Add(combination);
        }

        bool existEqualSubset = false;
        foreach (List<int> combination in list)
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