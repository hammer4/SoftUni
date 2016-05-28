using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int len = Math.Max(array1.Length, array2.Length);
            int[] result = new int[len];

            for(int i=0; i<len; i++)
            {
                result[i] = array1[i % array1.Length] + array2[i % array2.Length];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
