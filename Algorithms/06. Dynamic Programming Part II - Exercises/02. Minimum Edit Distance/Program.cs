using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static int replaceCost;
    private static int insertCost;
    private static int deleteCost;
    private static int[,] editCost;

    public static void Main()
    {
        char[] delimeters = new[] { '=', ' ' };

        replaceCost = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray()[0];
        insertCost = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray()[0];
        deleteCost = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray()[0];
        string first = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray()[1].Trim();
        string second = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray()[1].Trim();

        Compute(first, second);
    }

    private static void Compute(string first, string second)
    {
        int firstLen = first.Length;
        int secondLen = second.Length;
        editCost = new int[firstLen + 1, secondLen + 1];

        for (int row = 0; row <= firstLen; row++)
        {
            editCost[row, 0] = row * deleteCost;
        }

        for (int col = 0; col <= secondLen; col++)
        {
            editCost[0, col] = col * insertCost;
        }

        for (int row = 1; row <= firstLen; row++)
        {
            for (int col = 1; col <= secondLen; col++)
            {
                int cost = second[col - 1] == first[row - 1] ? 0 : replaceCost;

                int delete = editCost[row - 1, col] + deleteCost;
                int replace = editCost[row - 1, col - 1] + cost;
                int insert = editCost[row, col - 1] + insertCost;

                editCost[row, col] = Math.Min(Math.Min(delete, insert), replace);
            }
        }

        // uncomment to see DP matrix
        //for (int i = 0; i < firstLen + 1; i++)
        //{
        //    for (int j = 0; j < secondLen + 1; j++)
        //    {
        //        Console.Write("{0,3}", editCost[i, j]);
        //    }

        //    Console.WriteLine();
        //}

        PrintResult(first, second, firstLen, secondLen);
    }

    private static void PrintResult(string first, string second, int firstLen, int secondLen)
    {
        Console.WriteLine("Minimum edit distance: " + editCost[firstLen, secondLen]);

        var resultOperations = new Stack<string>();
        int fIndex = firstLen;
        int sIndex = secondLen;
        while (fIndex > 0 && sIndex > 0)
        {
            if (first[fIndex - 1] == second[sIndex - 1])
            {
                fIndex--;
                sIndex--;
            }
            else
            {
                int replace = editCost[fIndex - 1, sIndex - 1] + replaceCost;
                int delete = editCost[fIndex - 1, sIndex] + deleteCost;
                int insert = editCost[fIndex, sIndex - 1] + insertCost;
                if (replace <= delete && replace <= insert)
                {
                    resultOperations.Push($"REPLACE({fIndex - 1}, {second[sIndex - 1]})");
                    fIndex--;
                    sIndex--;
                }
                else if (delete < replace && delete < insert)
                {
                    resultOperations.Push($"DELETE({fIndex - 1})");
                    fIndex--;
                }
                else
                {
                    resultOperations.Push($"INSERT({sIndex - 1}, {second[sIndex - 1]})");
                    sIndex--;
                }
            }
        }

        while (fIndex > 0)
        {
            resultOperations.Push($"DELETE({fIndex - 1})");
            fIndex--;
        }

        while (sIndex > 0)
        {
            resultOperations.Push($"INSERT({sIndex - 1}, {second[sIndex - 1]})");
            sIndex--;
        }

        foreach (string resultOperation in resultOperations)
        {
            Console.WriteLine(resultOperation);
        }
    }
}