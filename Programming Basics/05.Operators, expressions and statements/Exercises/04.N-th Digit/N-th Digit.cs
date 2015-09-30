using System;

class NthDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int nDigit, m=1;
        for (int i = 0; i < n - 1; i++)
            m *= 10;
        nDigit = (number / m) % 10;
        if (number / m < 1)
            Console.WriteLine("-");
        else
            Console.WriteLine(nDigit);
    }
}
