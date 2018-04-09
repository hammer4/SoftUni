using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[] lzs = FindLZS(numbers);
        Console.WriteLine(string.Join(" ", lzs));
    }

    private static int[] FindLZS(int[] numbers)
    {
        int count = numbers.Length;
        int[] len = new int[count];
        int[] prev = new int[count];
        int maxLen = 0;
        int lastIndex = -1;

        for (int i = 0; i < count; i++)
        {
            len[i] = 1;
            prev[i] = -1;
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    if (j == 0 && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                    else if (prev[j] >= 0 && numbers[prev[j]] > numbers[j] && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
                else
                {
                    if (j == 0 && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                    else if (prev[j] >= 0 && numbers[prev[j]] < numbers[j] && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
            }

            if (len[i] > maxLen)
            {
                maxLen = len[i];
                lastIndex = i;
            }
        }

        var result = new Stack<int>();
        while (lastIndex >= 0)
        {
            result.Push(numbers[lastIndex]);
            lastIndex = prev[lastIndex];
        }

        return result.ToArray();
    }
}