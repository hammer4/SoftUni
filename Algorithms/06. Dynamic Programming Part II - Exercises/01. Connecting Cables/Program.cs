using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        int[] side1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


        int[] side2 = side1
            .OrderBy(c => c)
            .ToArray();

        int result = FindMaxConnections(side1, side2);

        Console.WriteLine($"Maximum pairs connected: {result}");
    }

    private static int FindMaxConnections(int[] side1, int[] side2)
    {
        int length = side1.Length;
        int[,] connectingCounts = new int[length + 1, length + 1];

        for (int i = 1; i <= length; i++)
        {
            for (int j = 1; j <= length; j++)
            {
                if (side1[i - 1] == side2[j - 1])
                {
                    connectingCounts[i, j] = connectingCounts[i - 1, j - 1] + 1;
                }
                else
                {
                    connectingCounts[i, j] = Math.Max(connectingCounts[i - 1, j], connectingCounts[i, j - 1]);
                }
            }
        }

        return connectingCounts[length, length];
    }
}