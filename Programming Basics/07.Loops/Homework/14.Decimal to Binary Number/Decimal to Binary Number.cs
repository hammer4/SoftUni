using System;
using System.Numerics;

class DecimalToBinaryNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }
        BigInteger multiplier = 1;
        BigInteger nBinary = 0;
        int binaryDigit = 0;
        while (n > 0)
        {
            binaryDigit = n % 2;
            nBinary += binaryDigit * multiplier;
            multiplier *= 10;
            n /= 2;
        }
        if (binaryDigit == 0)
        {
            nBinary += multiplier;
        }
        string binary = nBinary.ToString();
        Console.WriteLine(binary);
    }
}
