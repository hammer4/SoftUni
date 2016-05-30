using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Build_a_Matrix_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            int currentChar = 'A';

            for(int i=0; i<rows; i++)
            {
                matrix[i] = new char[cols];
                for(int j=0; j<cols; j++)
                {
                    matrix[i][j] = (char)currentChar++;
                }
            }

            for(int i=0; i<matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
