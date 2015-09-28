using System;
using System.Linq;

class MatrixShuffling
{
    static void Main()
    {
        int numberOfRows = int.Parse(Console.ReadLine());
        int numberOfCols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[numberOfRows, numberOfCols];
        
        for(int i=0; i<matrix.GetLength(0); i++)
        {
            for(int j=0; j<matrix.GetLength(1); j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        string command = Console.ReadLine();
        
        while(command != "END")
        {
            if( (command.Substring(0,5) != "swap "))
            {
                Console.WriteLine("Invalid input!");
                command = Console.ReadLine();
                continue;
            }
            
            int[] coordinates = command.Substring(5, command.Length-5).Split(' ').Select(int.Parse).ToArray();

            if((coordinates.Length != 4) || coordinates[0]<0 || coordinates[0]>matrix.GetLength(0)-1 || coordinates[1]<0 || coordinates[1]>matrix.GetLength(1)-1 || coordinates[2]<0 || coordinates[2]>matrix.GetLength(0)-1 || coordinates[3]<0 || coordinates[3]>matrix.GetLength(1)-1)
            {
                Console.WriteLine("Invalid input!");
                command = Console.ReadLine();
                continue;
            }

            string changer = matrix[coordinates[0], coordinates[1]];
            matrix[coordinates[0], coordinates[1]] = matrix[coordinates[2],coordinates[3]];
            matrix[coordinates[2],coordinates[3]] = changer;

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    Console.Write("{0, -10}", matrix[i,j]);
                }
                Console.WriteLine();
            }

            command = Console.ReadLine();
        }
    }
}
