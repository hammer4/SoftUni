using System;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        for(int i=1; i<= size; i++)
        {
            PrintRow(size, i);
        }

        for(int i=size-1; i>=1; i--)
        {
            PrintRow(size, i);
        }
    }

    private static void PrintRow(int size, int i)
    {
        for(int j=1; j<=size - i; j++)
        {
            Console.Write(" ");
        }

        for(int j=1; j<=i; j++)
        {
            Console.Write("* ");
        }

        Console.WriteLine();
    }
}