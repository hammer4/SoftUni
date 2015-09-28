using System;

public class MatrixMultiplication
{
    static void Main()
    {
        int[,] firstMatrix = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

        // Print the first matrix
        for (int row = 0; row < firstMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < firstMatrix.GetLength(1); col++)
            {
                Console.Write("{0} ", firstMatrix[row, col]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        int[,] secondMatrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

        // Print the second matrix
        for (int row = 0; row < secondMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < secondMatrix.GetLength(1); col++)
            {
                Console.Write("{0} ", secondMatrix[row, col]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        // Multiply the first matrix with the second matrix
        int width1 = firstMatrix.GetLength(1);
        int height1 = firstMatrix.GetLength(0);
        int width2 = secondMatrix.GetLength(1);
        int height2 = secondMatrix.GetLength(0);

        if (width1 != height2)
        {
            throw new ArgumentException("Invalid dimensions!");
        }

        int[,] resultMatrix = new int[height1, width2];
        for (int row = 0; row < height1; row++)
        {
            for (int col = 0; col < width2; col++)
            {
                resultMatrix[row, col] = 0;
                for (int i = 0; i < width1; i++)
                {
                    resultMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
                }
            }
        }

        // Print the result matrix
        for (int row = 0; row < resultMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < resultMatrix.GetLength(1); col++)
            {
                Console.Write("{0} ", resultMatrix[row, col]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
