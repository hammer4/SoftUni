using System;

class TheExplorer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        TopBottom(n);
        UpperMiddle(n);
        Middle(n);
        LowerMiddle(n);
        TopBottom(n);
    }

    static void TopBottom (int n)
    {
        string dash = new string('-', n / 2);
        Console.WriteLine("{0}*{0}", dash);
    }

    static void UpperMiddle (int n)
    {
        for (int i=1; i<=n-4; i=i+2)
        {
            string outerDash = new string('-', (n - i - 2)/2);
            string innerDash = new string('-', i);
            Console.WriteLine("{0}*{1}*{0}", outerDash, innerDash);
        }
    }

    static void Middle (int n)
    {
        string dash = new string('-', n - 2);
        Console.WriteLine("*{0}*", dash);
    }

    static void LowerMiddle (int n)
    {
        for (int i = n-4; i >= 1; i = i - 2)
        {
            string outerDash = new string('-', (n - i - 2)/2);
            string innerDash = new string('-', i);
            Console.WriteLine("{0}*{1}*{0}", outerDash, innerDash);
        }
    }
}
