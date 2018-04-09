using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static HashSet<string> results = new HashSet<string>();
    public static void Main()
    {
        int[] coins = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int sum = int.Parse(Console.ReadLine());

        int combinations = FindCombinationForGivenSum(coins, sum);
        Console.WriteLine(combinations);
    }

    private static int FindCombinationForGivenSum(int[] coins, int sum)
    {
        int[,] maxCombCount = new int[coins.Length + 1, sum + 1];
        for (int i = 0; i <= coins.Length; i++)
        {
            maxCombCount[i, 0] = 1;
        }

        for (int i = 1; i <= coins.Length; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (coins[i - 1] <= j)
                {
                    maxCombCount[i, j] = maxCombCount[i - 1, j] + maxCombCount[i, j - coins[i - 1]];
                }
                else
                {
                    maxCombCount[i, j] = maxCombCount[i - 1, j];
                }
            }
        }

        return maxCombCount[coins.Length, sum];
    }
}