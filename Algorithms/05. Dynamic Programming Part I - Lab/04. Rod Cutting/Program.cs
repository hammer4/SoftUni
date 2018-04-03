using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int[] price;
    static int[] bestPrice;
    static int[] bestCombo;

    static void Main(string[] args)
    {
        price = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        bestPrice = new int[price.Length];
        bestCombo = new int[price.Length];

        int n = int.Parse(Console.ReadLine());

        int totalBest = CutRod(n);

        List<int> result = new List<int>();

        while(n > 0)
        {
            int next = bestCombo[n];
            result.Add(next);
            n -= next;
        }

        Console.WriteLine(totalBest);
        Console.WriteLine(String.Join(" ", result));
    }

    private static int CutRod(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            int currentBest = bestPrice[i];
            for (int j = 1; j <= i; j++)
            {
                currentBest =
                     Math.Max(bestPrice[i], price[j] + bestPrice[i - j]);
                if (currentBest > bestPrice[i])
                {
                    bestPrice[i] = currentBest;
                    bestCombo[i] = j;
                }
            }
        }
        return bestPrice[n];
    }
}