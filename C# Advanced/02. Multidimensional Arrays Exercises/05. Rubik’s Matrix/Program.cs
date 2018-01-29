using System;
using System.Linq;

namespace _05._Rubik_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];
            int counter = 1;

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter++;
                }
            }

            int commandsCount = int.Parse(Console.ReadLine());

            for(int i=0; i<commandsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[1])
                {
                    case "up":
                        ShiftUp(matrix, command);
                        break;
                    case "down":
                        ShiftDown(matrix, command);
                        break;
                    case "right":
                        ShiftRight(matrix, command);
                        break;
                    case "left":
                        ShiftLeft(matrix, command);
                        break;
                }
            }

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    bool isFound = false;

                    for(int k=i; k<matrix.GetLength(0); k++)
                    {
                        int l = k == i ? j : 0;
                        for (; l<matrix.GetLength(1); l++)
                        {
                            if(matrix[k,l] == i * matrix.GetLength(1) + j + 1)
                            {
                                if(k==i && l == j)
                                {
                                    Console.WriteLine("No swap required");
                                }
                                else
                                {
                                    int temp = matrix[i, j];
                                    matrix[i, j] = matrix[k, l];
                                    matrix[k, l] = temp;
                                    Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})");
                                }

                                isFound = true;
                                break;

                            }
                        }

                        if (isFound)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static void Print(int[,] matrix)
        {
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void ShiftLeft(int[,] matrix, string[] command)
        {
            int row = int.Parse(command[0]);
            int shiftsCount = int.Parse(command[2]) % matrix.GetLength(1);

            for (int i = 0; i < shiftsCount; i++)
            {
                int start = matrix[row, 0];
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[row, j] = matrix[row, j + 1];
                }

                matrix[row, matrix.GetLength(1) - 1] = start;
            }
        }

        private static void ShiftRight(int[,] matrix, string[] command)
        {
            int row = int.Parse(command[0]);
            int shiftsCount = int.Parse(command[2]) % matrix.GetLength(1);

            for (int i = 0; i < shiftsCount; i++)
            {
                int end = matrix[row, matrix.GetLength(1) - 1];
                for (int j = matrix.GetLength(1) - 1; j > 0; j--)
                {
                    matrix[row, j] = matrix[row, j-1];
                }

                matrix[row, 0] = end;
            }
        }

        private static void ShiftDown(int[,] matrix, string[] command)
        {
            int col = int.Parse(command[0]);
            int shiftsCount = int.Parse(command[2]) % matrix.GetLength(0);

            for (int i = 0; i < shiftsCount; i++)
            {
                int end = matrix[matrix.GetLength(0) - 1, col];
                for (int j = matrix.GetLength(0) - 1; j > 0; j--)
                {
                    matrix[j, col] = matrix[j - 1, col];
                }

                matrix[0, col] = end;
            }
        }

        private static void ShiftUp(int[,] matrix, string[] command)
        {
            int col = int.Parse(command[0]);
            int shiftsCount = int.Parse(command[2]) % matrix.GetLength(0);

            for(int i=0; i<shiftsCount; i++)
            {
                int start = matrix[0, col];

                for(int j=0; j<matrix.GetLength(0) - 1; j++)
                {
                    matrix[j, col] = matrix[j + 1,col];
                }

                matrix[matrix.GetLength(0) - 1, col] = start;
            }
        }
    }
}
