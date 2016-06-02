using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Max_Platform
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[][] matrix = new int[rows][];

            for(int i =0; i<rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            long maxSum = long.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for(int i=0; i<rows-2; i++)
            {
                for(int j=0; j<cols-2; j++)
                {
                    long currentSum = (long)matrix[i][j] + (long)matrix[i][j + 1] + (long)matrix[i][j + 2] + (long)matrix[i + 1][j] + (long)matrix[i + 1][j + 1] + (long)matrix[i + 1][j + 2] + (long)matrix[i + 2][j] + (long)matrix[i + 2][j + 1] + (long)matrix[i + 2][j + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine(maxSum);

            for(int i= maxRow; i<=maxRow+2; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i].Skip(maxCol).Take(3)));
            }
        }
    }
}
