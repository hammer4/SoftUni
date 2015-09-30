using System;

class BitSifting
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int sieves = int.Parse(Console.ReadLine());
        int bits1=0;
        for (int i = 1; i <= sieves; i++)
        {
            ulong sieve = ulong.Parse(Console.ReadLine());
            number &= ~sieve;
        }
        for (int i = 0; i <= 63; i++)
        {
            if ((number & 1) % 2 == 1)
                bits1++;
            number >>= 1;
        }
        Console.WriteLine(bits1);
    }
}
