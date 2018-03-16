using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static char[,] labyrinth;
    static List<char> path = new List<char>();

    static void Main(string[] args)
    {
        labyrinth = ReadLabyrinth();
        FindPaths(0, 0, 'S');
    }

    private static void FindPaths(int row, int col, char direction)
    {
        if (!IsInBounds(row, col))
        {
            return;
        }

        path.Add(direction);

        if (IsExit(row, col))
        {
            PrintPath();
        }
        else if (IsFree(row, col))
        {
            Mark(row, col);
            FindPaths(row, col + 1, 'R');
            FindPaths(row + 1, col, 'D');
            FindPaths(row, col - 1, 'L');
            FindPaths(row - 1, col, 'U');
            Unmark(row, col);
        }

        path.RemoveAt(path.Count - 1);
    }

    private static void Unmark(int row, int col)
    {
        labyrinth[row, col] = '-';
    }

    private static void Mark(int row, int col)
    {
        labyrinth[row, col] = 'v';
    }

    private static bool IsFree(int row, int col)
    {
        return labyrinth[row, col] == '-';
    }

    private static void PrintPath()
    {
        Console.WriteLine(String.Join(String.Empty, path.Skip(1)));
    }

    private static bool IsExit(int row, int col)
    {
        return labyrinth[row, col] == 'e';
    }

    private static bool IsInBounds(int row, int col)
    {
        bool isRowExisting = row >= 0 && row < labyrinth.GetLength(0);
        bool isColExisting = col >= 0 && col < labyrinth.GetLength(1);

        return isRowExisting && isColExisting;
    }

    private static char[,] ReadLabyrinth()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        char[,] labyrinth = new char[rows, cols];

        for (int i = 0; i < labyrinth.GetLength(0); i++)
        {
            string line = Console.ReadLine();

            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                labyrinth[i, j] = line[j];
            }
        }

        return labyrinth;
    }
}