using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        n >>= p;
        int bitAtPositionP = n & 1;
        Console.WriteLine(bitAtPositionP);
    }
}
