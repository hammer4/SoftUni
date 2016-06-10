using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Target_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            int[,] resultMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = matrix[i, j];
                }
            }

            int[] element = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementRow = element[0];
            int elementCol = element[1];

            for (int i = elementRow - 1; i <= elementRow + 1; i++)
            {
                for (int j = elementCol - 1; j <= elementCol + 1; j++)
                {
                    if (i == elementRow && j == elementCol)
                    {
                        resultMatrix[i, j] *= matrix[i - 1, j - 1] + matrix[i - 1, j] + matrix[i - 1, j + 1] + matrix[i, j - 1] + matrix[i, j + 1] + matrix[i + 1, j - 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    }
                    else
                    {
                        resultMatrix[i, j] *= matrix[elementRow, elementCol];
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
