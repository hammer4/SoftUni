using System;
using System.Numerics;

class CalculateNFactorialDividedByKFMultiactorialMultipliedByNMinusKFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers 100>n>k>1:");
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k=");
        int k = int.Parse(Console.ReadLine());

        BigInteger result = Factorial(n) / (Factorial(k) * Factorial(n - k));
        Console.WriteLine(result);
    }

    static BigInteger Factorial(int n)
    {
        BigInteger factorial = 1;
        for(int i=1; i<=n; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}