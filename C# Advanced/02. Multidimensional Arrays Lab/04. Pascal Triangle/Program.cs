using System;

namespace _04._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] jagged = new long[height][];

            for(int i=1; i<=height; i++)
            {
                jagged[i - 1] = new long[i];
                jagged[i - 1][0] = 1;
                jagged[i - 1][jagged[i - 1].Length - 1] = 1;
            }

            for(int i=2; i<height; i++)
            {
                for(int j=1; j<jagged[i].Length - 1; j++)
                {
                    jagged[i][j] = jagged[i - 1][j - 1] + jagged[i - 1][j];
                }
            }

            for(int i=0; i<jagged.Length; i++)
            {
                Console.WriteLine(String.Join(" ", jagged[i]));
            }
        }
    }
}
