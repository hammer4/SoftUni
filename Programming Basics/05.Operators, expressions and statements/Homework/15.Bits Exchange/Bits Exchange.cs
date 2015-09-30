using System;

class BitsExchange
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        uint mask1 = 7 & (n >> 3);
        uint mask2 = 7 & (n >> 24);
        n &= 4177526783;
        n |= mask1<<24;
        n &= 4294967239;
        n |= mask2<<3;
        Console.WriteLine(n);
    }
}
