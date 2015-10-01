using System;
using System.Numerics;

class BinaryToDecimalNumber
{
    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger n = BigInteger.Parse(input);
        int nInDecimal = 0;
        int multiplier = 1;
        BigInteger binaryDigit = 0;
        while (n > 0)
        {
            binaryDigit = n % 10;
            nInDecimal += (int)binaryDigit * multiplier;
            multiplier *= 2;
            n /= 10;
        }
        Console.WriteLine(nInDecimal);
    }
}
