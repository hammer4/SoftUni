using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static char[] permutation;
    private static void Main()
    {
        permutation = Console.ReadLine()
            .Split()
            .Select(Char.Parse)
            .ToArray();

        PermuteRep(0);
    }

    private static void PermuteRep(int start)
    {
        if (start >= permutation.Length)
        {
            Console.WriteLine(string.Join(" ", permutation));
        }
        else
        {
            PermuteRep(start + 1);

            var used = new HashSet<char> { permutation[start] };

            for (var i = start + 1; i < permutation.Length; i++)
            {
                if (!used.Contains(permutation[i]))
                {
                    used.Add(permutation[i]);
                    Swap(start, i);
                    PermuteRep(start + 1);

                    Swap(start, i);
                }
            }
        }
    }

    private static void Swap(int i, int j)
    {
        var temp = permutation[i];
        permutation[i] = permutation[j];
        permutation[j] = temp;
    }
}