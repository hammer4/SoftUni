using System;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        foreach (char character in input)
        {
            Console.Write("\\u" + ((int)character).ToString("X").PadLeft(4, '0'));
        }

        Console.WriteLine();
    }
}