using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int d = n % 10;
        int c = (n / 10) % 10;
        int b = (n / 100) % 10;
        int a = (n / 1000) % 10;

        int sum = a + b + c + d;
        int reversed = d * 1000 + c * 100 + b * 10 + a;
        int lastDigitToFirst = d * 1000 + a * 100 + b * 10 + c;
        int secondAndThirdExchange = a * 1000 + c * 100 + b * 10 + d;

        Console.WriteLine(sum);
        Console.WriteLine(reversed);
        Console.WriteLine(lastDigitToFirst);
        Console.WriteLine(secondAndThirdExchange);
    }
}
