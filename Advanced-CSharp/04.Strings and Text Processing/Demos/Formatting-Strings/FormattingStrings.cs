using System;
using System.Globalization;

public class FormattingStrings
{
    public static void Main()
    {
        Console.Write("The current culture is: ");
        Console.WriteLine(System.Threading.Thread.CurrentThread.CurrentCulture);

        int number = 42;
        string s = number.ToString("D5"); // 00042
        Console.WriteLine(s);

        s = number.ToString("X"); // 2A
        Console.WriteLine(s);

        s = number.ToString("x4"); // 002a
        Console.WriteLine(s);

        // Chаnge the default culture to Bulgarian
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        Console.WriteLine("Bulgarian price: {0:C}", number); // 42,00 лв.

        // Print the currency as Canadian dollars
        CultureInfo culture = new CultureInfo("fr-CA");
        s = number.ToString("C", culture); // 42,00 $
        Console.WriteLine("Price for Canada: " + s);

        double d = 0.375;
        s = d.ToString("F2"); // 0,38
        Console.WriteLine(s);

        s = d.ToString("F10"); // 0,3750000000
        Console.WriteLine(s);

        s = d.ToString("P2"); // 37,50 %
        Console.WriteLine(s);

        string template = "If I were {0}, I would {1}.";
        string sentence1 = string.Format(template, "developer", "know C#");
        Console.WriteLine(sentence1); // If I were developer, I would know C#.

        string sentence2 = string.Format(template, "elephant", "weigh 4500 kg");
        Console.WriteLine(sentence2); // If I were elephant, I would weigh 4500 kg.

        s = string.Format("{0,10:D}", number); // "        42"
        Console.WriteLine(s);

        s = string.Format("{0,10:F5}", d); // "   0,37500"
        Console.WriteLine(s);

        Console.WriteLine("Dec {0:D} = Hex {1:X}", number, number); // "Dec 42 = Hex 2A"

        DateTime now = DateTime.Now;
        Console.WriteLine("Now is {0:d.MM.yyyy HH:mm:ss}.", now); // Now is 31.03.2006 08:30:32

        // Print the date and time in English (Canada)
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        Console.WriteLine(now.ToString("dddd, MMMM dd, yyyy h:mm:ss tt"));

        // Print the date and time in Russian (Russia)
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
        Console.WriteLine(now.ToString("dd MMMM yyyy (dddd), H:mm:ss"));

        Console.WriteLine(1.25); // 1.25 -> the separator will be "," (Russia)

        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.WriteLine(1.25); // 1.25 -> the separator will be "." (Invariant)
    }
}
