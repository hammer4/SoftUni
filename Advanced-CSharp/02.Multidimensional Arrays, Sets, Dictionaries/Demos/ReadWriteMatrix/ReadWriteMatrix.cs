using System;

public class ReadWriteMatrix
{
    static void Main()
    {
        // Read the matrix dimensions
        Console.Write("Number of rows = ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Number of columns = ");
        int cols = int.Parse(Console.ReadLine());

        // Allocate the matrix
        int[,] matrix = new int[rows, cols];

        // Enter the matrix elements
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("matrix[{0},{1}] = ", row, col);
                int element = int.Parse(Console.ReadLine());
                matrix[row, col] = element;
            }
        }

        // Print the matrix on the console
        Console.WriteLine();
        Console.WriteLine("The matrix is as follows:");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}
