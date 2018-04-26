using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static char[,] matrix;
    static bool[,] visited;
    static Dictionary<char, int> counts;

    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        InitializeMatrix(rows);
        counts = new Dictionary<char, int>();

        for(int i=0; i<matrix.GetLength(0); i++)
        {
            for(int j=0; j<matrix.GetLength(1); j++)
            {
                if (!visited[i, j])
                {
                    if (!counts.ContainsKey(matrix[i, j]))
                    {
                        counts[matrix[i,j]] = 0;
                    }

                    TraverseMatrix(i, j, matrix[i, j]);
                    counts[matrix[i, j]]++;
                }
            }
        }

        Console.WriteLine($"Areas: {counts.Values.Sum()}");

        foreach(var ch in counts.Keys.OrderBy(c => c))
        {
            Console.WriteLine($"Letter '{ch}' -> {counts[ch]}");
        }
    }

    private static void TraverseMatrix(int i, int j, char ch)
    {
        if(i >= 0 && i<matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1) && visited[i, j] == false && matrix[i,j] == ch)
        {
            visited[i, j] = true;
            TraverseMatrix(i - 1, j, ch);
            TraverseMatrix(i + 1, j, ch);
            TraverseMatrix(i, j - 1, ch);
            TraverseMatrix(i, j + 1, ch);
        }
    }

    private static void InitializeMatrix(int rows)
    {
        char[] line = Console.ReadLine().ToCharArray();
        matrix = new char[rows, line.Length];

        for (int j = 0; j < line.Length; j++)
        {
            matrix[0, j] = line[j];
        }

        for (int i=1; i<rows; i++)
        {
            line = Console.ReadLine().ToCharArray();

            for(int j=0; j<line.Length; j++)
            {
                matrix[i, j] = line[j];
            }
        }

        visited = new bool[rows, line.Length];
    }
}