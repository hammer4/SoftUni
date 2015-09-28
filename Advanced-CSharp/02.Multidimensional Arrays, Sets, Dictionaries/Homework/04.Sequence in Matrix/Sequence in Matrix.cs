using System;

class SequenceinMatrix
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];
        int maxElemRow = 0;
        int maxElemCol = 0;
        int longestSeq = 1;
        int counter = 1;

        for(int i=0; i<matrix.GetLength(0); i++)
        {
            for(int j=0; j<matrix.GetLength(1); j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        //check horizontally
        for(int i=0; i<matrix.GetLength(0); i++)
        {
            for(int j=0; j<matrix.GetLength(1)-1; j++)
            {
                if (matrix[i,j] == matrix[i,j+1])
                {
                    counter++;
                    if(counter>longestSeq)
                    {
                        longestSeq = counter;
                        maxElemRow = i;
                        maxElemCol = counter - j;
                    }
                }
            }
            counter = 1;
        }

        //check vertically
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0) - 1; j++)
            {
                if (matrix[j, i] == matrix[j + 1, i])
                {
                    counter++;
                    if (counter > longestSeq)
                    {
                        longestSeq = counter;
                        maxElemRow = counter - j;
                        maxElemCol = i;
                    }
                }
            }
            counter = 1;
        }

        //check diagonally
        for(int i=0; i<matrix.GetLength(0)-1; i++)
        {
            for(int j=0; j<matrix.GetLength(1)-1; j++)
            {
                if(matrix[i,j]==matrix[i+1,j+1])
                {
                    int r = i;
                    int c = j;
                    while ((matrix[r, c] == matrix[r + 1, c + 1]))
                    {
                            counter++;
                            if (counter > longestSeq)
                            {
                                longestSeq = counter;
                                maxElemRow = i;
                                maxElemCol = j;
                            }
                        r++;
                        c++;
                        if (r == matrix.GetLength(0) - 1 || c == matrix.GetLength(1) - 1)
                            break;
                    }
                }
            }
            counter = 1;
        }
        
        //print the longest sequence
        string[] valueOfSeq = new string[longestSeq];
        for(int i =0; i<longestSeq; i++)
        {
            valueOfSeq[i] = matrix[maxElemRow, maxElemCol];
        }

        Console.WriteLine(String.Join(", ", valueOfSeq));
    }
}