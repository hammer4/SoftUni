using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private const int SIZE = 8;
    private static bool[,] chessboard = new bool[SIZE, SIZE];

    static HashSet<int> attackedRows = new HashSet<int>();
    static HashSet<int> attackedColumns = new HashSet<int>();
    static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
    static HashSet<int> attackedRightDiagonals = new HashSet<int>();

    static void Main(string[] args)
    {
        PutQueens(0);
    }

    static void PutQueens(int row)
    {
        if(row == SIZE)
        {
            PrintSolution();
        }
        else
        {
            for (int col = 0; col < SIZE; col++)
            {
                if(CanPlaceQueen(row, col))
                {
                    MarkAllAttackedPositions(row, col);
                    PutQueens(row + 1);
                    UnmarkAllAttackedPositions(row, col);
                }
            }
        }
    }

    private static void UnmarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Remove(row);
        attackedColumns.Remove(col);
        attackedLeftDiagonals.Remove(col - row);
        attackedRightDiagonals.Remove(col + row);

        chessboard[row, col] = false;
    }

    private static void MarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Add(row);
        attackedColumns.Add(col);
        attackedLeftDiagonals.Add(col - row);
        attackedRightDiagonals.Add(col + row);

        chessboard[row, col] = true;
    }

    private static bool CanPlaceQueen(int row, int col)
    {
        bool isRowAttacked = attackedRows.Contains(row);
        bool isColumnAttacked = attackedColumns.Contains(col);
        bool isLeftDiagonalAttacked = attackedLeftDiagonals.Contains(col - row);
        bool isRightDiagonalAttacked = attackedRightDiagonals.Contains(col + row);

        return !(isRowAttacked || isColumnAttacked || isLeftDiagonalAttacked || isRightDiagonalAttacked);
    }

    private static void PrintSolution()
    {
        for(int i= 0; i<chessboard.GetLength(0); i++)
        {
            for(int j=0; j<chessboard.GetLength(1); j++)
            {
                Console.Write(chessboard[i,j] ? '*' : '-');
                Console.Write(' ');
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}