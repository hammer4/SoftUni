using System;
using System.Linq;

namespace _09._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] jagged = new int[sizes[0]][];

            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[sizes[1]];

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = i * jagged[i].Length + j + 1;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] parameters = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int targetRow = parameters[0];
                int targetCol = parameters[1];
                int radius = parameters[2];

                for (int i = Math.Max(0, targetRow - radius); i <= Math.Min(targetRow + radius, jagged.Length - 1); i++)
                {

                    if (jagged[i].Length > targetCol && targetCol >= 0)
                    {
                        jagged[i][targetCol] = 0;
                    }

                    if (i == targetRow)
                    {
                        for (int j = Math.Max(0, targetCol - radius); j <= Math.Min(targetCol + radius, jagged[i].Length - 1); j++)
                        {
                            jagged[i][j] = 0;
                        }
                    }
                }

                for (int i = 0; i < jagged.Length; i++)
                {
                    int count = 0;

                    for(int j=0; j<jagged[i].Length; j++)
                    {
                        if(jagged[i][j] != 0)
                        {
                            count++;
                        }
                    }

                    int[] newArr = new int[count];
                    int index = 0;

                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        if (jagged[i][j] != 0)
                        {
                            newArr[index++] = jagged[i][j];
                        }
                    }

                    jagged[i] = newArr;

                    if(newArr.Length == 0)
                    {
                        for(int j=i; j < jagged.Length - 1; j++)
                        {
                            jagged[j] = jagged[j + 1];
                        }

                        jagged[jagged.Length - 1] = null;
                        i--;
                    }

                    count = 0;

                    for(int j=0; j<jagged.Length; j++)
                    {
                        if(jagged[j] != null)
                        {
                            count++;
                        }
                    }

                    int[][] newJagged = new int[count][];
                    index = 0;

                    for(int j=0; j<jagged.Length; j++)
                    {
                        if(jagged[j] != null)
                        {
                            newJagged[index++] = jagged[j];
                        }
                    }

                    jagged = newJagged;
                }
            }

            Print(jagged);
        }

        private static void Print(int[][] jagged)
        {
            foreach (int[] array in jagged)
            {
                Console.WriteLine($"{String.Join(" ", array)}");
            }
        }
    }
}
