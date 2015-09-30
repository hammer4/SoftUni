using System;

class BigAndOdd
{
    static void Main()
    {
        int n=int.Parse(Console.ReadLine());
        bool result = n > 20 && n % 2 == 1;
        Console.WriteLine(result);

    }
}
