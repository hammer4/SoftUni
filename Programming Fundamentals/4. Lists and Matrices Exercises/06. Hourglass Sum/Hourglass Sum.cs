using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Hourglass_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[6][];
            for(int i=0; i<6; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            int maxSum = int.MinValue;

            for(int i =0; i<matrix.Length-2; i++)
            {
                for(int j=0; j<matrix[i].Length - 2; j++)
                {
                    int currentSum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2] + matrix[i + 1][j + 1] + matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
