using System;

class LastDigit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int lastDigit = n % 10;
        Console.WriteLine(lastDigit);
    }
}
