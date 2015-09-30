using System;

class BitwiseExtractBit3
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        n >>= 3;
        int thirdBitValue = n & 1;
        Console.WriteLine(thirdBitValue);
    }
}
