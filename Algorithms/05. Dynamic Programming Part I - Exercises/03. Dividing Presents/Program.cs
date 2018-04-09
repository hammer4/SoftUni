using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        int[] presents = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int totalSum = presents.Sum();

        int[] alanPresents = FindSubsetSum(presents, totalSum);
        int alanSum = alanPresents.Sum();

        Console.WriteLine($"Difference: {Math.Abs(totalSum - alanSum * 2)}");
        Console.WriteLine($"Alan:{alanSum} Bob:{totalSum - alanSum}");
        Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
        Console.WriteLine("Bob takes the rest.");
    }

    private static int[] FindSubsetSum(int[] presents, int totalSum)
    {
        var sums = new Dictionary<int, int> { { 0, 0 } };

        for (int i = 0; i < presents.Length; i++)
        {
            foreach (var sum in sums.Keys.ToArray())
            {
                int newSum = sum + presents[i];

                if (!sums.ContainsKey(newSum))
                {
                    sums.Add(newSum, presents[i]);
                }
            }
        }


        int halfSum = totalSum / 2;
        for (int i = halfSum; i >= 0; i--)
        {
            if (sums.ContainsKey(i))
            {
                return RecoverSubSequence(sums, i);
            }
        }

        return new int[0];
    }

    private static int[] RecoverSubSequence(Dictionary<int, int> sums, int sum)
    {
        var result = new List<int>();

        while (sum > 0)
        {
            result.Add(sums[sum]);
            sum -= sums[sum];
        }

        return result.ToArray();
    }
}