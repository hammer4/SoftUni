using System;
using System.Numerics;

class CalculateNFactorialDividedByKFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers 100>n>k>1:");
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k=");
        int k = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;

        for(int i= k+1; i<=n; i++)
        {
            factorial *= i;
        }
        Console.WriteLine(factorial);
    }
}