using System;

class CheckABitAtGivenPosition
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        bool bitAtPositionP = ((n >> p) & 1)%2 == 1;
        Console.WriteLine(bitAtPositionP);
    }
}
