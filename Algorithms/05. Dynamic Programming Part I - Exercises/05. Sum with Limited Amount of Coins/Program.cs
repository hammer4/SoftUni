using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        int[] coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

        int sum = int.Parse(Console.ReadLine());

        int comb = Findcombinations(coins, sum);
        Console.WriteLine(comb);
    }

    private static int Findcombinations(int[] coins, int sum)
    {
        int[,] maxCount = new int[coins.Length + 1, sum + 1];
        for (int i = 0; i <= coins.Length; i++)
        {
            maxCount[i, 0] = 1;
        }

        for (int i = 1; i <= coins.Length; i++)
        {
            for (int j = sum; j >= 0; j--)
            {
                if (coins[i - 1] <= j && maxCount[i - 1, j - coins[i - 1]] != 0)
                {
                    maxCount[i, j]++;
                }
                else
                {
                    maxCount[i, j] = maxCount[i - 1, j];
                }
            }
        }

        int count = 0;
        for (int i = 0; i <= coins.Length; i++)
        {
            if (maxCount[i, sum] != 0)
            {
                count++;
            }
        }

        return count;
    }
}