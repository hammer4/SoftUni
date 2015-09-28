using System;

class TextFilter
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] banList = input.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
        input = Console.ReadLine();
        string output = input;

        for(int i = 0; i<banList.Length; i++)
        {
            output = output.Replace(banList[i], new string('*', banList[i].Length));
        }

        Console.WriteLine(output);
    }
}