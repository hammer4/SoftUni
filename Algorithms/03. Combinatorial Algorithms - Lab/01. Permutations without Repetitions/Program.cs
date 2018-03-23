using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static char[] permutation;

    static void Main(string[] args)
    {
        permutation = Console.ReadLine()
            .Split()
            .Select(Char.Parse)
            .ToArray();

        Permute(0);
    }

    private static void Permute(int index)
    {
        if (index >= permutation.Length)
        {
            Console.WriteLine(string.Join(" ", permutation));
        }
        else
        {
            Permute(index + 1);
            for (int i = index + 1; i < permutation.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }
    }

    private static void Swap(int index, int i)
    {
        var temp = permutation[index];
        permutation[index] = permutation[i];
        permutation[i] = temp;
    }
}
