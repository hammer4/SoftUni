using System;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        string reversedString = string.Empty;

        for(int i = input.Length-1; i>=0; i--)
        {
            reversedString = string.Concat(reversedString, input[i]);
        }

        Console.WriteLine(reversedString);
    }
}
