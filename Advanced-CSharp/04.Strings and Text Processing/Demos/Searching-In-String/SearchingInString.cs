using System;

public class SearchingInString
{
    public static void Main()
    {
        const string Str = "C# Programming Course";

        int index = Str.IndexOf("C#"); // index = 0
        Console.WriteLine(index);

        index = Str.IndexOf("Course"); // index = 15
        Console.WriteLine(index);

        // IndexOf is case-sensetive. -1 means not found
        index = Str.IndexOf("COURSE"); // index = -1
        Console.WriteLine(index);

        // Case-insensitive IndexOf
        index = Str.ToLower().IndexOf("COURSE".ToLower()); // 18
        Console.WriteLine(index);

        index = Str.IndexOf("ram"); // index = 7
        Console.WriteLine(index);

        index = Str.IndexOf("r"); // index = 4
        Console.WriteLine(index);

        index = Str.IndexOf("r", 5); // index = 7
        Console.WriteLine(index);

        index = Str.IndexOf("r", 8); // index = 18
        Console.WriteLine(index);
    }
}