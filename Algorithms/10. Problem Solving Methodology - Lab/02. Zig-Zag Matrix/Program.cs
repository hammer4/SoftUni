using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int numberOfRows = int.Parse(Console.ReadLine());
        int numberOfColumns = int.Parse(Console.ReadLine());

        int[][] matrix = new int[numberOfRows][];
        ReadMatrix(numberOfRows, matrix);

        int[,] maxPaths = new int[numberOfRows, numberOfColumns];
        int[,] previousRowIndex = new int[numberOfRows, numberOfColumns];

        for(int row=1; row<numberOfRows; row++)
        {
            maxPaths[row, 0] = matrix[row][0];
        }

        for(int col = 1; col < numberOfColumns; col++)
        {
            for(int row = 0; row < numberOfRows; row++)
            {
                int previousMax = 0;

                if(col % 2 != 0)
                {
                    for(int i = row + 1; i<numberOfRows; i++)
                    {
                        if(maxPaths[i, col - 1] > previousMax)
                        {
                            previousMax = maxPaths[i, col - 1];
                            previousRowIndex[row, col] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < row; i++)
                    {
                        if (maxPaths[i, col - 1] > previousMax)
                        {
                            previousMax = maxPaths[i, col - 1];
                            previousRowIndex[row, col] = i;
                        }
                    }
                }

                maxPaths[row, col] = previousMax + matrix[row][col];
            }
        }

        var currentRowIndex = GetLAstRowIndexOfPath(maxPaths, numberOfColumns);

        var path = RecoverMaxPath(numberOfColumns, matrix, currentRowIndex, previousRowIndex);
        Console.WriteLine($"{path.Sum()} = {String.Join(" + ", path)}");
    }

    private static List<int> RecoverMaxPath(int numberOfColumns, int[][] matrix, int currentRowIndex, int[,] previousRowIndex)
    {
        List<int> path = new List<int>();
        int columnIndex = numberOfColumns - 1;

        while(columnIndex >= 0)
        {
            path.Add(matrix[currentRowIndex][columnIndex]);
            currentRowIndex = previousRowIndex[currentRowIndex, columnIndex];

            columnIndex--;
        }

        path.Reverse();

        return path;
    }

    private static int GetLAstRowIndexOfPath(int[,] maxPaths, int numberOfColumns)
    {
        int currentRowIndex = -1;
        int globalMax = 0;
        for(int row = 0; row < maxPaths.GetLength(0); row++)
        {
            if(maxPaths[row, numberOfColumns - 1] > globalMax)
            {
                globalMax = maxPaths[row, numberOfColumns - 1];
                currentRowIndex = row;
            }
        }

        return currentRowIndex;
    }

    private static void ReadMatrix(int numberOfRows, int[][] matrix)
    {
        for(int i=0; i<numberOfRows; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
        }
    }
}