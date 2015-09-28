using System;

public class SlowBuildingStrings
{
    public static void Main()
    {
        DateTime startTime = DateTime.Now;

        Console.WriteLine("Concatenation of 50 000 chars...");
        ConcatenateCharacter('a', 50000);

        DateTime endTime = DateTime.Now;
        Console.WriteLine("... done in {0} seconds", endTime - startTime);

        startTime = DateTime.Now;

        Console.WriteLine("Concatenation of 200 000 chars...");
        ConcatenateCharacter('a', 200000);

        endTime = DateTime.Now;
        Console.WriteLine("... done in {0} seconds", endTime - startTime);
    }

    private static string ConcatenateCharacter(char ch, int count)
    {
        string result = string.Empty;

        for (int i = 0; i < count; i++)
        {
            result += ch;
        }

        return result;
    }
}
