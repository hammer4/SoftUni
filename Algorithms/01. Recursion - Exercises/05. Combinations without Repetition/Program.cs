using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static int[] vector;
    private static int[] set;

    static void Main(string[] args)
    {
        int setCount = int.Parse(Console.ReadLine());
        int vectorCount = int.Parse(Console.ReadLine());

        set = Enumerable.Range(1, setCount).ToArray();
        vector = new int[vectorCount];

        GenCombs(0, 0);
    }

    static void GenCombs(int setIndex, int vectorIndex)
    {
        if(vectorIndex == vector.Length)
        {
            PrintVector();
        }
        else
        {
            for(int i=setIndex; i<set.Length; i++)
            {
                vector[vectorIndex] = set[i];
                GenCombs(i + 1, vectorIndex + 1);
            }
        }
    }

    private static void PrintVector()
    {
        Console.WriteLine(String.Join(" ", vector));
    }
}