using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter an integer number 1<n<100");
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        BigInteger nthCatalanNumber = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
        Console.WriteLine("The n-th Catalan number is: " + nthCatalanNumber);
    }

    static BigInteger Factorial(int n)
    {
        BigInteger factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}