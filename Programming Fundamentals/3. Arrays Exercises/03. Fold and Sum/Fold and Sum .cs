using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = array.Length / 4;
            int[] upperRow = new int[k * 2];
            int[] lowerRow = new int[k * 2];

            for(int i=0; i<k; i++)
            {
                upperRow[i] = array[k - i - 1];
                upperRow[upperRow.Length - i - 1] = array[array.Length - k + i];
                lowerRow[2*i] = array[2*i + k];
                lowerRow[2 * i + 1] = array[2 * i + k + 1];
            }

            int[] result = new int[k * 2];

            for (int i = 0; i<result.Length; i++)
            {
                result[i] = upperRow[i] + lowerRow[i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
