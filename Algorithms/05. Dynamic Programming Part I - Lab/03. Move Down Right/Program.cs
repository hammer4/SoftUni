using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static long[,] cells;
    static long[,] sum;

    static void Main(string[] args)
    {
        InitializeMatrix();
        FillSums();
        IEnumerable<string> path = FindPath();

        Console.WriteLine(String.Join(" ", path));
    }

    private static List<string> FindPath()
    {
        List<string> path = new List<string>();
        int row = sum.GetLength(0) - 1;
        int col = sum.GetLength(1) - 1;

        while(row + col > 0)
        {
            if(col == 0)
            {
                path.Add($"[{row--}, {col}]");
                continue;
            }

            if(row == 0)
            {
                path.Add($"[{row}, {col--}]");
                continue;
            }

            if(sum[row, col - 1] >= sum[row - 1, col])
            {
                path.Add($"[{row}, {col--}]");
            }
            else
            {
                path.Add($"[{row--}, {col}]");
            }
        }

        path.Add($"[{row}, {col}]");
        path.Reverse();

        return path;
    }

    private static void InitializeMatrix()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        cells = sum = new long[rows, cols];

        for(int i=0; i<cells.GetLength(0); i++)
        {
            long[] row = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            for(int j=0; j<cells.GetLength(1); j++)
            {
                cells[i, j] = row[j];
            }
        }
    }

    private static void FillSums()
    {
        for (int row = 0; row < cells.GetLength(0); row++)
        {
            for (int col = 0; col < cells.GetLength(1); col++)
            {
                long maxPrevCell = long.MinValue;
                if (col > 0 && sum[row, col - 1] > maxPrevCell)
                {
                    maxPrevCell = sum[row, col - 1];
                }

                if (row > 0 && sum[row - 1, col] > maxPrevCell)
                {
                    maxPrevCell = sum[row - 1, col];
                }
                sum[row, col] = cells[row, col];

                if (maxPrevCell != long.MinValue)
                {
                    sum[row, col] += maxPrevCell;
                }
            }
        }
    }
}