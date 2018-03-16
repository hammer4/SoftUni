using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(Sum(array, 0));
    }

    private static int Sum(int[] array, int index)
    {
        if(index == array.Length)
        {
            return 0;
        }

        return array[index] + Sum(array, index + 1);
    }
}