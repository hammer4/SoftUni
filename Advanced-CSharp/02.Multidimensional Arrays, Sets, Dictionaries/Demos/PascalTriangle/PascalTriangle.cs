using System;

public class PascalTriangle
{
    private static int height;

    private static long[][] triangle;

    private static void Main()
    {
        height = 10;

        // Allocate the array in a triangle form
        triangle = new long[height + 1][];

        for (int row = 0; row <= height; row++)
        {
            triangle[row] = new long[row + 1];
        }

        // Calculate Triangle
        triangle[0][0] = 1;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                triangle[row + 1][col] += triangle[row][col];
                triangle[row + 1][col + 1] += triangle[row][col];
            }
        }

        // Print Triangle
        for (int row = 0; row <= height; row++)
        {
            Console.Write("".PadLeft((height - row) * 2));
            for (int col = 0; col <= row; col++)
            {
                Console.Write("{0,3} ", triangle[row][col]);
            }

            Console.WriteLine();
        }
    }
}
