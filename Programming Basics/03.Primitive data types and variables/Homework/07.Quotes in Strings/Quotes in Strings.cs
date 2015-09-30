using System;

class QuotesinStrings
{
    static void Main()
    {
        string string1 = "The \"use\" of quotations causes difficulties.";
        string string2 = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(string1);
        Console.WriteLine(string2);
    }
}
