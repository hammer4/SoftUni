using System;
using System.Linq;

namespace _04._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for(int i=0; i<matrix.GetLength(0) - 2; i++)
            {
                for(int j=0; j<matrix.GetLength(1) - 2; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for(int i=maxRow; i<=maxRow+2; i++)
            {
                for(int j=maxCol; j<=maxCol+2; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
