using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Matrices
{
    class Matrices
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            char type = char.Parse(tokens[0]);
            int rows = int.Parse(tokens[1]);
            int cols = int.Parse(tokens[2]);
            int[][] matrix = new int[rows][];
            for(int i =0; i<rows; i++)
            {
                matrix[i] = new int[cols];
            }

            switch(type)
            {
                case 'A': A(matrix, rows, cols); break;
                case 'B': B(matrix, rows, cols); break;
                case 'C': C(matrix, rows, cols); break;
                case 'D': D(matrix, rows, cols); break;
            }

            for(int i=0; i<rows; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        static void A(int[][] matrix, int rows, int cols)
        {
            int counter = 1;

            for(int i=0; i<cols; i++)
            {
                for(int j=0; j<rows; j++)
                {
                    matrix[j][i] = counter++;
                }
            }
        }

        static void B(int[][] matrix, int rows, int cols)
        {
            int counter = 1;

            for(int i=0; i<cols; i++)
            {
                int k = i % 2 == 0 ? 0 : matrix.Length-1;
                
                for(int j=k; j<matrix.Length && j >=0; j= k==0 ? j+1 : j-1)
                {
                    matrix[j][i] = counter++;
                } 
            }
        }

        static void C(int[][] matrix, int rows, int cols)
        {
            int counter = 1;
            int difference = rows - 1;
            //for(int k=rows-1 + cols-1; k>=0; k--)
            while(difference > -cols)
            {
                for(int i=0; i<rows; i++)
                {
                    for(int j = 0; j < cols; j++)
                    {
                        if(i-j == difference)
                        {
                            matrix[i][j] = counter++;
                        }
                    }
                }
                difference--;
            }
        }

        static void D(int[][] matrix, int rows, int cols)
        {
            int startRow = 0;
            int startCol = 0;
            int endRow = rows - 1;
            int endCol = cols - 1;
            int k = 1;
            while (true)
            {
                bool endLoop = false;
                for (int i = startRow; i <= endRow; i++)
                {
                    matrix[i][startCol] = k++;
                    if(k > rows * cols)
                    {
                        return;
                    }
                }

                for (int i = startCol + 1; i <= endCol; i++)
                {
                    matrix[endRow][i] = k++;
                    if (k > rows * cols)
                    {
                        return;
                    }
                }

                for (int i = endRow - 1; i >= startRow; i--)
                {
                    matrix[i][endCol] = k++;
                    if (k > rows * cols)
                    {
                        return;
                    }
                }

                for (int i = endCol - 1; i > startCol; i--)
                {
                    matrix[startRow][i] = k++;
                    if (k > rows * cols)
                    {
                        return;
                    }
                }

                startCol++;
                startRow++;
                endRow--;
                endCol--;
            }
        }

    }
}
