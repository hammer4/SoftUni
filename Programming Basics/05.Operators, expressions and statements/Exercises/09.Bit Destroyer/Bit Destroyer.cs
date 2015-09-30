using System;

    class BitDestroyer
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int mask, newNumber;
            mask = 1 << p;
            mask = ~mask;
            newNumber = n & mask;
            Console.WriteLine(newNumber);
        }
    }
