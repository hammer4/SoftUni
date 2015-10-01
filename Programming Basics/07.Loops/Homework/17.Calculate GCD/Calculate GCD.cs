using System;

class CalculateGCD
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        if (a < 0)
            a *= -1;
        if (b < 0)
            b *= -1;
        if (a == 0)
        {
            Console.WriteLine(b);
            return;
        }
        if (b == 0)
        {
            Console.WriteLine(a);
            return;
        }
        while (a != b)
        {
            if (a > b)
            {
                a -= b;
            }
            else
            {
                b -= a;
            }
        }
        Console.WriteLine(a);
    }
}