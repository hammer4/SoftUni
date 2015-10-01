using System;

class CountSubstringOccurrences
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = Console.ReadLine();
        int counter = 0;

        for(int i=0; i<=input.Length-pattern.Length; i++)
        {
            if(input.Substring(i, pattern.Length).ToLower().Equals(pattern.ToLower()))
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}
