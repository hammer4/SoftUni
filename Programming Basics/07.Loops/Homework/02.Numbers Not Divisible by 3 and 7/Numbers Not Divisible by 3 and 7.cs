using System;

class NumbersNotDivisibleBy3and7
{
    static void Main()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        for (int i=1; i<=n; i++)
        {
            if (i%3 ==0 || i%7 ==0)
            {
                continue;
            }
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}