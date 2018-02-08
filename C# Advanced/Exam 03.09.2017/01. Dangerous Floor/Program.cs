using System;

namespace _01._Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            for(int i=0; i<matrix.GetLength(0); i++)
            {
                string[] row = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j][0];
                }
            }

            string command;

            while((command = Console.ReadLine()) != "END")
            {
                char piece = command[0];
                byte startRow = byte.Parse(command[1].ToString());
                byte startCol = byte.Parse(command[2].ToString());
                byte endRow = byte.Parse(command[4].ToString());
                byte endCol = byte.Parse(command[5].ToString());

                if(matrix[startRow, startCol] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if(!CanMove(piece, startRow, startCol, endRow, endCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if(endRow > 7 || endCol > 7)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                matrix[startRow, startCol] = 'x';
                matrix[endRow, endCol] = piece;
            }
        }

        private static bool CanMove(char piece, byte startRow, byte startCol, byte endRow, byte endCol)
        {
            switch (piece)
            {
                case 'K':
                    return Math.Max(Math.Abs(endRow - startRow), Math.Abs(endCol - startCol)) == 1;
                case 'B':
                    return Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol);
                case 'R':
                    return startRow == endRow || startCol == endCol;
                case 'Q':
                    return Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol) || (startRow == endRow || startCol == endCol);
                case 'P':
                    return startCol == endCol && startRow == endRow + 1;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
