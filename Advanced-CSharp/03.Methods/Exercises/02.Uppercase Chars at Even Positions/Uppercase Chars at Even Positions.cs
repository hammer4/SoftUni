using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(UpperCaseCharsAtEvenPositions(input));
    }

    static string UpperCaseCharsAtEvenPositions(string input)
    {
        char[] array = input.ToCharArray();
        for(int i=0; i<array.Length; i+=2)
        {
            if(array[i]>=97 && array[i]<=122)
            {
                array[i] =(char)(array[i] - 32);
            }
        }

        return new string(array);
    }
}