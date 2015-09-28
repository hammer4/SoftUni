using System;

public class FirstExample
{
    public static void Main()
    {
        const string Sentence = "Stand up, stand up, Balkan superman.";

        Console.WriteLine("Sentence = \"{0}\"", Sentence);
        Console.WriteLine("Sentence.Length = {0}", Sentence.Length);

        for (int i = 0; i < Sentence.Length; i++)
        {
            Console.WriteLine("s[{0}] = {1}", i, Sentence[i]);
        }

        foreach (var ch in Sentence)
        {
            Console.Write(ch);
        }

        Console.WriteLine();
    }
}