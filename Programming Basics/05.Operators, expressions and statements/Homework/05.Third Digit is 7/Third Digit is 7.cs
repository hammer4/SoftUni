using System;

class ThirdDigitIs7
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool thirdDigitIs7 = (n / 100) % 10 == 7;
        Console.WriteLine(thirdDigitIs7);
    }
}
