using System;

class NumbersFrom1toN
{
    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());
        for (int i=1; i<=n; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}