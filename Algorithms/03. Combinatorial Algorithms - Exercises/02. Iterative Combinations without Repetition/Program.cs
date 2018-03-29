using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static char[] set;

    static void Main(string[] args)
    {
        set = Console.ReadLine()
            .Split()
            .Select(Char.Parse)
            .ToArray();

        int k = int.Parse(Console.ReadLine());

        foreach(var combination in Combinations(set, k))
        {
            Console.WriteLine(String.Join(" ", combination));
        }
    }

    static bool NextCombination(int[] num, int n, int k)
    {
        bool finished, changed;

        changed = finished = false;

        if (k > 0)
        {
            for (int i = k - 1; !finished && !changed; i--)
            {
                if (num[i] < (n - 1) - (k - 1) + i)
                {
                    num[i]++;
                    if (i < k - 1)
                    {
                        for (int j = i + 1; j < k; j++)
                        {
                            num[j] = num[j - 1] + 1;
                        }
                    }
                    changed = true;
                }
                finished = (i == 0);
            }
        }

        return changed;
    }

    private static IEnumerable<IEnumerable<char>> Combinations(IEnumerable<char> elements, int k)
    {
        char[] elem = elements.ToArray();
        int size = elem.Length;

        if (k <= size)
        {
            int[] numbers = new int[k];
            for (int i = 0; i < k; i++)
            {
                numbers[i] = i;
            }

            do
            {
                yield return numbers.Select(n => elem[n]);
            }
            while (NextCombination(numbers, size, k));
        }
    }
}
