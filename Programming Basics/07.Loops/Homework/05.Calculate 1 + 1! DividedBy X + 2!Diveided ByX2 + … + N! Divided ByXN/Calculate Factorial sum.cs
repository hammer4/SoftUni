using System;
using System.Numerics;

class CalculateFactorialSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        decimal factorielOfN = 1;
        decimal powerOfX = 1;
        decimal sum = 1;
        
        for (int i =1; i<=n; i++)
        {
            factorielOfN *= i;
            powerOfX *= x;
            sum += (decimal)factorielOfN / powerOfX;
        }
        Console.WriteLine("{0:F5}", sum);
    }
}