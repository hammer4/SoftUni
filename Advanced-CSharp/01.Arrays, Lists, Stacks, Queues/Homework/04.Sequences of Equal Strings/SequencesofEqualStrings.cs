using System;

class SequencesofEqualStrings
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] strings = input.Split(' ');

        for(int i=0; i<strings.Length-1; i++)
        {
            Console.Write(strings[i]);
            if(strings[i+1].Equals(strings[i]))
            {
                Console.Write(" ");
            }
            else
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine(strings[strings.Length - 1]);
    }
}