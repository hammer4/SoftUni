using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];

            for(int i=0; i<rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            }

            int counter = 0;

            for(int i=0; i<rows-1; i++)
            {
                for(int j=0; j<cols-1; j++)
                {
                    if(matrix[i][j] == matrix[i][j+1] && matrix[i][j] == matrix[i+1][j] && matrix[i][j] == matrix[i+1][j+1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
