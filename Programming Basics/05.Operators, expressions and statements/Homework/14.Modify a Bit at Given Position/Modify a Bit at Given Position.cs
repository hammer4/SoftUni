using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());

        if ((n >> p) % 2 == v)
            Console.WriteLine(n);
        else
            if (v == 0)
            {
                n = n & ~(1 << p);
                Console.WriteLine(n);
            }
            else
            {
                n = n ^ (1 << p);
                Console.WriteLine(n);
            }

    }
}
