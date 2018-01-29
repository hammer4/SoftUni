using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> words = new List<string>();

            string input;

            while((input = Console.ReadLine()) != "END")
            {
                words.Add(input);
            }

            int length = words.OrderByDescending(w => w.Length).First().Length;

            char[,] matrix = new char[words.Count, length];

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                string word = words[i].PadRight(length);
                
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = word[j];
                }
            }

            int degrees = int.Parse(command.Substring(command.IndexOf('(') + 1 ,command.IndexOf(')') - command.IndexOf('(') - 1));

            degrees = degrees % 360;

            switch (degrees)
            {
                case 90:
                    Rotate90(ref matrix);
                    break;
                case 180:
                    Rotate180(ref matrix);
                    break;
                case 270:
                    Rotate270(ref matrix);
                    break;
            }

            Print(matrix);
        }

        private static void Rotate270(ref char[,] matrix)
        {
            char[,] result = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[result.GetLength(0) - j - 1, i] = matrix[i, j];
                }
            }

            matrix = result;
        }

        private static void Rotate180(ref char[,] matrix)
        {
            char[,] result = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[result.GetLength(0) - i - 1, result.GetLength(1) - j - 1] = matrix[i, j];
                }
            }

            matrix = result;
        }

        private static void Rotate90(ref char[,] matrix)
        {
            char[,] result = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    result[j, result.GetLength(1) - i - 1] = matrix[i, j];
                }
            }

            matrix = result;
        }

        private static void Print(char[,] matrix)
        {
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
