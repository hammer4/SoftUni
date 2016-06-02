using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for(int i =0; i<size; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            int mainDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    if(i == j)
                    {
                        mainDiagonalSum += matrix[i][j];
                    }

                    if(i + j == size-1)
                    {
                        secondaryDiagonalSum += matrix[i][j];
                    }
                }
            }

            Console.WriteLine(Math.Abs(mainDiagonalSum - secondaryDiagonalSum));
        }
    }
}
