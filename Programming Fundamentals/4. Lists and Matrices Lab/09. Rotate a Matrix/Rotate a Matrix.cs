using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Rotate_a_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            string[][] matrix = new string[rows][];
            string[][] result = new string[cols][];

            for (int i=0; i<rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ');
            }

            for(int i = 0; i<cols; i++)
            {
                result[i] = new string[rows];
                for(int j = rows-1, k=0; j>=0; j--,k++)
                {
                    result[i][k] = matrix[j][i];
                }
            }

            for(int i = 0; i<result.Length; i++)
            {
                Console.WriteLine(string.Join(" ", result[i]));
            }
        }
    }
}
