using System;

class CollecttheCoins
{
    static void Main()
    {
        char[][] array = new char[4][];
        
        for(int i=0; i<array.Length; i++)
        {
            string input = Console.ReadLine();
            array[i] = new char[input.Length]; 
            for(int j=0; j<input.Length; j++)
            {
                array[i][j] = input[j];
            }
        }

        int posRow = 0;
        int posCol = 0;
        int coins = 0;
        int walls = 0;

        string commands = Console.ReadLine();

        foreach(char direction in commands)
        {
            switch(direction)
            {
                case 'v': posRow++; break;
                case '<': posCol--; break;
                case '^': posRow--; break;
                case '>': posCol++; break;
                default: Console.WriteLine("Incorrect input."); return;
            }

            if(posRow > array.Length-1)
            {
                posRow = array.Length - 1;
                walls++;
                continue;
            }
            if(posRow<0)
            {
                posRow = 0;
                walls++;
                continue;
            }
            if(posCol>array[posRow].Length-1)
            {
                switch(direction)
                {
                    case '^': posRow++; break;
                    case '>': posCol--; break;
                    case 'v': posRow--; break;
                }
                walls++;
                continue;
            }
            if(posCol<0)
            {
                posCol = 0;
                walls++;
                continue;
            }

            if(array[posRow][posCol] == '$')
            {
                coins++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Coins collected: {0}", coins);
        Console.WriteLine();
        Console.WriteLine("Walls hit: {0}", walls);
    }
}