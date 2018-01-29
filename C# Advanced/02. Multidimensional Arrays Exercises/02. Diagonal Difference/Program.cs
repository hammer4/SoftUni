using System;
using System.Linq;

namespace _02._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            long primary = 0;
            long secondary = 0;

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                primary += matrix[i, i];
                secondary += matrix[i, matrix.GetLength(1) - i - 1];
            }

            Console.WriteLine(Math.Abs(primary - secondary));
        }
    }
}
