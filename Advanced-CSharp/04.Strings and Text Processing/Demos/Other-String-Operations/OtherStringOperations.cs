using System;

public class OtherStringOperations
{
    public static void Main()
    {
        // String.Replace() example
        string cocktail = "Vodka + Martini + Cherry";
        string replaced = cocktail.Replace("+", "and");
        Console.WriteLine(replaced);

        // String.Remove() example
        string price = "$ 1234567";
        string lowPrice = price.Remove(2, 3);
        Console.WriteLine(lowPrice);

        // Uppercase and lowercase conversion examples
        string alpha = "aBcDeFg";
        string lowerAlpha = alpha.ToLower();
        Console.WriteLine(lowerAlpha);
        string upperAlpha = alpha.ToUpper();
        Console.WriteLine(upperAlpha);

        // Trim() example
        string s = "  example of white space ";
        string clean = s.Trim();
        Console.WriteLine(clean);

        // Trim(chars) example
        s = " \t\nHello!!! \n";
        clean = s.Trim(' ', ',', '!', '\n', '\t');
        Console.WriteLine(clean);

        // TrimStart() example
        s = "   C#   ";
        clean = s.TrimStart();
        Console.WriteLine(clean);

        // TrimEnd() example
        s = "   C#   ";
        clean = s.TrimEnd();
        Console.WriteLine(clean);
    }
}