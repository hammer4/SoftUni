using System;

class Arrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string outerDots = new string('.', n / 2);
        string innerDots;
        string sharp = new string('#', n);
        Console.WriteLine("{0}{1}{0}", outerDots, sharp);

        for(int i=2; i<n; i++)
        {
            innerDots = new string('.', n - 2);
            Console.WriteLine("{0}#{1}#{0}", outerDots, innerDots);
        }

        sharp = new string('#', n / 2);
        innerDots = new string('.', 2 * n - 1 - n / 2 - n / 2 - 2);
        Console.WriteLine("{0}#{1}#{0}", sharp, innerDots);

        for(int i=1; i<=n-2; i++)
        {
            outerDots = new string('.', i);
            innerDots = new string('.', 2*n-1 - 2 * i - 2);
            Console.WriteLine("{0}#{1}#{0}", outerDots, innerDots);
        }

        outerDots = new string('.', n - 1);
        Console.WriteLine("{0}#{0}", outerDots);
    }
}