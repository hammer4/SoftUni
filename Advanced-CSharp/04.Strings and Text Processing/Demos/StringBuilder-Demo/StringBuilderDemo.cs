using System;
using System.Diagnostics;
using System.Text;

public class StringBuilderDemo
{
    public static void Main()
    {
        string str = "Software University";

        string reversed = ReverseString(str);
        Console.WriteLine(reversed);

        string capitalLetters = ExtractCapitalLetters(str);
        Console.WriteLine(capitalLetters);

        Console.WriteLine("Concatenation of 200 000 chars...");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        ConcatenateChar('a', 200000);

        stopwatch.Stop();
        Console.WriteLine("... done in {0} seconds", stopwatch.Elapsed);
    }

    private static string ReverseString(string s)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = s.Length - 1; i >= 0; i--)
        {
            sb.Append(s[i]);
        }

        return sb.ToString();
    }

    private static string ExtractCapitalLetters(string s)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (char.IsUpper(ch))
            {
                result.Append(ch);
            }
        }

        return result.ToString();
    }

    private static string ConcatenateChar(char ch, int count)
    {
        StringBuilder result = new StringBuilder(count);

        for (int i = 0; i < count; i++)
        {
            result.Append(ch);
        }

        return result.ToString();
    }
}
