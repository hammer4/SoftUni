using System;

class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine();
        string output = string.Empty;

        for(int i=0; i<20; i++)
        {
            if(i<input.Length)
            {
                output = string.Concat(output, input[i]);
            }
            else
            {
                output = string.Concat(output, '*');
            }
        }

        Console.WriteLine(output);
    }
}