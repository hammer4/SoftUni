using System;
using System.Collections.Generic;

class FilltheMatrix
{
    static void Main()
    {
        Console.Write("Matrix size: ");
        int size = int.Parse(Console.ReadLine());
        Console.Write("Choose a pattern for filling (A/B): ");
        char choice = char.Parse(Console.ReadLine());
        int[,] matrix = new int[size,size];

        switch (choice)
        {
            case 'A': PatternA(matrix); break;
            case 'B': PatternB(matrix); break;
            default: Console.WriteLine("Incorrect input!");
                return;
        }

        Console.WriteLine();

        for(int i=0; i<matrix.GetLength(0); i++)
        {
            for(int j=0; j<matrix.GetLength(1); j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }
            Console.WriteLine();
        }

    }

    static void PatternA(int[,] matrix)
    {
        for(int i=0; i < matrix.GetLength(1); i++)
        {
            for(int j=0; j<matrix.GetLength(0); j++)
            {
                Console.Write("[{0}][{1}] = ", j, i);
                matrix[j, i] = int.Parse(Console.ReadLine());
            }
        }
    }

    static void PatternB(int[,] matrix)
    {
        for(int i=0; i<matrix.GetLength(1); i++)
        {
            int k = i%2==0? 0 : matrix.GetLength(0) - 1;
            for( int j = k; j<matrix.GetLength(0) && j>=0; j= k==0? j+1 : j-1)
            {
                Console.Write("[{0}][{1}] = ", j, i);
                matrix[j, i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
