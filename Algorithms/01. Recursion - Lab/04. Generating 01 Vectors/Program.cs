using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int bits = int.Parse(Console.ReadLine());
        int[] vector = new int[bits];
        Gen01(vector, 0);
    }

    private static void Gen01(int[] vector, int index)
    {
        if(index == vector.Length)
        {
            Console.WriteLine(String.Join("", vector));
            return;
        }

        for (int i = 0; i <= 1; i++)
        {
            vector[index] = i;
            Gen01(vector, index + 1);
        }
    }
}