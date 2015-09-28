using System;
using System.Collections.Generic;

class StringMatrixRotation
{
    static void Main()
    {
        string command = Console.ReadLine();
        int counter = 7;
        string degreesString = string.Empty;
        
        while(command[counter] >= 48 && command[counter]<= 57)
        {
            degreesString += command[counter];
            counter++;
        }

        int deg = int.Parse(degreesString);
        int degrees = deg % 360;
        List<List<char>> list = new List<List<char>>();
        
        string input = Console.ReadLine();
        counter = -1;
        int longestString = 1;

        while(input != "END")
        {
            counter++;
            if(input.Length>longestString)
            {
                longestString = input.Length;
            }
            
            list.Add(new List<char>());

            for(int i=0; i<input.Length; i++)
            {
                list[counter].Add(input[i]);
            }

            input = Console.ReadLine();
        }

        for(int i=0; i<list.Count; i++) // filling with spaces
        {
            for (int j = list[i].Count; j < longestString; j++)
            {
                list[i].Add(' ');
            }
        }

        switch(degrees)
        {
            case 0: Rotate0(list); break;
            case 90: Rotate90(list); break;
            case 180: Rotate180(list); break;
            case 270: Rotate270(list); break;
        }
    }

    static void Rotate0(List<List<char>> list)
    {
        foreach(List<char> list1 in list)
        {
            foreach(char character in list1)
            {
                Console.Write(character);
            }

            Console.WriteLine();
        }
    }

    static void Rotate90(List<List<char>> list)
    {
        for(int i=0; i<list[0].Count; i++)
        {
            for(int j=list.Count-1; j>=0; j--)
            {
                Console.Write(list[j][i]);
            }
            Console.WriteLine();
        }
    }

    static void Rotate180(List<List<char>> list)
    {
        for(int i=list.Count-1; i>=0; i--)
        {
            for (int j = list[i].Count - 1; j >= 0; j--)
            {
                Console.Write(list[i][j]);
            }

            Console.WriteLine();
        }
    }

    static void Rotate270(List<List<char>> list)
    {
        for(int i=list[0].Count-1; i>=0; i--)
        {
            for(int j=0; j<list.Count; j++)
            {
                Console.Write(list[j][i]);
            }

            Console.WriteLine();
        }
    }
}