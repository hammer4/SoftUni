using System;

class LettersChangeNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] strings = input.Split(new char[0],StringSplitOptions.RemoveEmptyEntries);
        double result = 0;

        foreach(string str in strings)
        {
            char firstChar = str[0];
            char lastChar = str[str.Length - 1];
            double number = double.Parse(str.Substring(1, str.Length - 2));

            if (char.IsUpper(firstChar))
            {
                result += number / (firstChar - 64);
            }
            else
            {
                result += number * (firstChar - 96);
            }

            if (char.IsUpper(lastChar))
            {
                result -= lastChar - 64;
            }
            else
            {
                result += lastChar - 96;
            }
        }

        Console.WriteLine("{0:F2}", result);
    }
}
