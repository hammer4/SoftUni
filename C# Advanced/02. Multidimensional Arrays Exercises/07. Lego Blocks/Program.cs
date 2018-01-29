using System;
using System.Linq;

namespace _07._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[][] jagged1 = new int[count][];
            int[][] jagged2 = new int[count][];
            int[][] result = new int[count][];

            for(int i=0; i<count; i++)
            {
                jagged1[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < count; i++)
            {
                jagged2[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for(int i=0; i<count; i++)
            {
                result[i] = new int[jagged1[i].Length + jagged2[i].Length];
                Array.Reverse(jagged2[i]);
                
                for(int j=0; j<jagged1[i].Length; j++)
                {
                    result[i][j] = jagged1[i][j];
                }

                for(int j=0; j<result[i].Length - jagged1[i].Length; j++)
                {
                    result[i][j + jagged1[i].Length] = jagged2[i][j];
                }
            }

            int length = result[0].Length;

            if(result.Any(a => a.Length != length))
            {
                Console.WriteLine("The total number of cells is: " + result.Sum(a => a.Length));
            }
            else
            {
                Print(result);
            }

        }

        private static void Print(int[][] jagged)
        {
            foreach(int[] array in jagged)
            {
                Console.WriteLine($"[{String.Join(", ", array)}]");
            }
        }
    }
}
