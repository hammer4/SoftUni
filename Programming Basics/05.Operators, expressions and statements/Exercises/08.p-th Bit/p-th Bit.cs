using System;

    class pthBit
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bitAtPositionP;
            n = n >> p;
            bitAtPositionP = n & 1;
            Console.WriteLine(bitAtPositionP);
        }
    }
