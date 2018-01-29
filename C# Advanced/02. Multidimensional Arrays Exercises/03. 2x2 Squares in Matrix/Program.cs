using System;
using System.Linq;

namespace _03._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int count = 0;

            for(int i=0; i<matrix.GetLength(0) - 1; i++)
            {
                for(int j=0; j<matrix.GetLength(1) - 1; j++)
                {
                    char current = matrix[i, j];
                    if (current == matrix[i, j+1] && current == matrix[i+1,j] && current == matrix[i + 1, j + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
