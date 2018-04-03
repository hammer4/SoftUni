using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int[] seq;
    static int[] len;
    static int[] prev;

    static void Main(string[] args)
    {
        seq = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        len = new int[seq.Length];
        prev = new int[seq.Length];

        int lastIndex = CalculateLIS();

        List<int> longestSeq = ConstructLIS(ref lastIndex);

        Console.WriteLine(String.Join(" ", longestSeq));
    }

    private static List<int> ConstructLIS(ref int lastIndex)
    {
        var longestSeq = new List<int>();

        while (lastIndex != -1)
        {
            longestSeq.Add(seq[lastIndex]);
            lastIndex = prev[lastIndex];
        }

        longestSeq.Reverse();
        return longestSeq;
    }

    private static int CalculateLIS()
    {
        int maxLen = 0;
        int lastIndex = -1;

        for (int x = 0; x < seq.Length; x++)
        {
            len[x] = 1;
            prev[x] = -1;

            for (int i = 0; i < x; i++)
            {
                if ((seq[i] < seq[x]) && (len[i] + 1 > len[x]))
                {
                    len[x] = len[i] + 1;
                    prev[x] = i;
                }
            }

            if (len[x] > maxLen)
            {
                maxLen = len[x];
                lastIndex = x;
            }
        }

        return lastIndex;
    }
}