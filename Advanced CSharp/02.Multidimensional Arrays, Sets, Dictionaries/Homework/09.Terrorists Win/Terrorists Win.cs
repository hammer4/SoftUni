using System;
using System.Collections.Generic;

class TerroristsWin
{
    static void Main()
    {
        string input = Console.ReadLine();
        int bombCounter = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '|')
            {
                bombCounter++;
            }
        }

        bombCounter /= 2;

        int[,] bombData = new int[bombCounter, 3];// second dimension is for current bomb: 0-start, 1-end, 2-power
        bombCounter = 0;
        bool bombArea = input[0] == '|' ? true : false;

        for (int i = 0; i < input.Length; i++)
        {
            if (bombArea)
            {
                if(i==0)
                {
                    bombData[bombCounter, 0] = i;
                    continue;
                }
                if (input[i] == '|')
                {
                    bombData[bombCounter, 1] = i;
                    bombArea = false;
                    bombData[bombCounter, 2] %= 10;
                    bombCounter++;
                }
                else
                {
                    bombData[bombCounter, 2] += input[i];
                }
            }
            else
            {
                if (input[i] == '|')
                {
                    bombData[bombCounter, 0] = i;
                    bombArea = true;
                }
            }
        }

        //reducing/increasing the start/end position of each bomb by its power
        for (int i = 0; i < bombData.GetLength(0); i++)
        {
            bombData[i, 0] -= bombData[i, 2];
            bombData[i, 1] += bombData[i, 2];
        }

        //Copy the bomb coordinates in a Set
        SortedSet<int> bombCoordinates = new SortedSet<int>();
        for (int i = 0; i < bombData.GetLength(0); i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                bombCoordinates.Add(bombData[i, j]);
            }
        }

        //printing the result
        bool damagedCharacter = bombData[0,0]<=0 ? true : false;
        for (int i = 0; i < input.Length; i++)
        {
            if (i > 0 && bombCoordinates.Contains(i))
            {
                Console.Write('.');
                damagedCharacter = !damagedCharacter;
            }
            else
            {
                if(damagedCharacter)
                {
                    Console.Write('.');
                }
                else
                {
                    Console.Write(input[i]);
                }
            }

        }
    }
}