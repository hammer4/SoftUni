using System;

class CalculateNFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal factorial = 1;

        for( int i=1; i<=n; i++)
        {
            factorial *= i;
        }
        Console.WriteLine(factorial);
    }
}