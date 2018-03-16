using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] set = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int count = int.Parse(Console.ReadLine());

        int[] vector = new int[count];

        GenCombs(set, vector, 0, 0);
    }

    private static void GenCombs(int[] set, int[] vector, int index, int border)
    {
        if(index == vector.Length)
        {
            Console.WriteLine(String.Join(" ", vector));
        }
        else
        {
            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                GenCombs(set, vector, index + 1, i + 1);
            }
        }
    }
}