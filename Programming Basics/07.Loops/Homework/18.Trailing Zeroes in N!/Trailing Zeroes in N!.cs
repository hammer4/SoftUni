using System;
using System.Numerics;

class TrailingZeroesInNFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        for (int i = 1; i <= n; i++)
            factorial *= i;
        int counter = 0;
        while (factorial % 10 == 0)
        {
            counter++;
            factorial /= 10;
        }
        Console.WriteLine(counter);
    }
}