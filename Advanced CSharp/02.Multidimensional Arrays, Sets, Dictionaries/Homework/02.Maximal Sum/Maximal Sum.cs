using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[,] matrix = new int[size[0], size[1]];

        for(int i=0; i<matrix.GetLength(0); i++)
        {
            int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }

        int maxSum = int.MinValue;
        int maxCol = 0;
        int maxRow = 0;

        if(matrix.GetLength(0)<3 || matrix.GetLength(1)<3)
        {
            Console.WriteLine("No 3X3 platform in this matrix.");
            return;
        }
        else if(matrix.GetLength(0)==3 && matrix.GetLength(1)>3)
        {
            int row = 0;
            for(int col=0; col<matrix.GetLength(1)-2; col++)
            {
                int sum = matrix[row,col] + matrix[row,col+1] + matrix[row, col+2] + matrix[row+1, col] + matrix[row+1, col+1] + matrix[row+1,col+2] + matrix[row+2,col] + matrix[row+2, col+1] + matrix[row+2, col+2];
                if(sum>maxSum)
                {
                    maxSum = sum;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }
        else if(matrix.GetLength(0)>3 && matrix.GetLength(1)==3)
        {
            int col = 0;
            for(int row=0; row<matrix.GetLength(0)-2; row++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }
        else
        {
            for (int row=0; row<matrix.GetLength(0)-2; row++)
            {
                for(int col=0; col<matrix.GetLength(1)-2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Sum = {0}", maxSum);

        for(int i = maxRow; i<=maxRow+2; i++)
        {
            for(int j=maxCol; j<=maxCol+2; j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}