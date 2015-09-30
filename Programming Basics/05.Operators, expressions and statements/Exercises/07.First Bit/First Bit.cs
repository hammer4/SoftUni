using System;

class FirstBit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int bitAtPosition1;
        n = n >> 1;
        bitAtPosition1 = n & 1;
        Console.WriteLine(bitAtPosition1);
    }
}
