using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool isOdd = Math.Abs(n % 2) == 1;
        Console.WriteLine(isOdd);
    }
}
