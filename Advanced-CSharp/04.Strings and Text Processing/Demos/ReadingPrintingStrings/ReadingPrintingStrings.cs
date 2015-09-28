using System;

public class ReadingPrintingStrings
{
    public static void Main()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Hello, {0}!", name);
    }
}