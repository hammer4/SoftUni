using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Matrix_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<List<int>> matrix = new List<List<int>>();

            for(int i=0; i<rows; i++)
            {
                matrix.Add(new List<int>());
                matrix[i] = new List<int>();
                matrix[i].AddRange(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            }

            string command = Console.ReadLine();
            while(command != "end")
            {
                string[] tokens = command.Split(' ');

                switch(tokens[0])
                {
                    case "remove":
                        switch(tokens[1])
                        {
                            case "positive":
                                RemovePositive(matrix, tokens);
                                break;
                            case "negative":
                                RemoveNegative(matrix, tokens);
                                break;
                            case "even":
                                RemoveEven(matrix, tokens);
                                break;
                            case "odd":
                                RemoveOdd(matrix, tokens);
                                break;
                        }
                        break;
                    case "swap":
                        int firstRow = int.Parse(tokens[1]);
                        int secondRow = int.Parse(tokens[2]);
                        List<int> changer = matrix[firstRow];
                        matrix[firstRow] = matrix[secondRow];
                        matrix[secondRow] = changer;
                        break;
                    case "insert":
                        int row = int.Parse(tokens[1]);
                        int element = int.Parse(tokens[2]);
                        matrix[row].Insert(0, element);
                        break;
                }

                command = Console.ReadLine();
            }

            foreach(var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static void RemovePositive(List<List<int>> matrix, string[] tokens)
        {
            int index = int.Parse(tokens[3]);

            if (tokens[2] == "row")
            {
                matrix[index] = matrix[index].Where(x => x < 0).ToList();
            }
            else
            {
                for(int i=0; i<matrix.Count; i++)
                {
                    if(matrix[i].Count > index)
                    {
                        if(matrix[i][index] >= 0)
                        {
                            matrix[i].RemoveAt(index);
                        }
                    }
                }
            }
        }

        static void RemoveNegative(List<List<int>> matrix, string[] tokens)
        {
            int index = int.Parse(tokens[3]);

            if (tokens[2] == "row")
            {
                matrix[index] = matrix[index].Where(x => x >= 0).ToList();
            }
            else
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i].Count > index)
                    {
                        if (matrix[i][index] < 0)
                        {
                            matrix[i].RemoveAt(index);
                        }
                    }
                }
            }
        }

        static void RemoveEven(List<List<int>> matrix, string[] tokens)
        {
            int index = int.Parse(tokens[3]);

            if (tokens[2] == "row")
            {
                matrix[index] = matrix[index].Where(x => x % 2 != 0).ToList();
            }
            else
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i].Count > index)
                    {
                        if (matrix[i][index] % 2 == 0)
                        {
                            matrix[i].RemoveAt(index);
                        }
                    }
                }
            }
        }

        static void RemoveOdd(List<List<int>> matrix, string[] tokens)
        {
            int index = int.Parse(tokens[3]);

            if (tokens[2] == "row")
            {
                matrix[index] = matrix[index].Where(x => x % 2 == 0).ToList();
            }
            else
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i].Count > index)
                    {
                        if (matrix[i][index] % 2 != 0)
                        {
                            matrix[i].RemoveAt(index);
                        }
                    }
                }
            }
        }
    }
}
