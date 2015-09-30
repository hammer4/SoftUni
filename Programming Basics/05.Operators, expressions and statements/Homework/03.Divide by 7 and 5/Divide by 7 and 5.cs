using System;

class DivideBy7and5
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool divisibleBy7And5 = n % 7 == 0 && n % 5 == 0 && n!=0;
        Console.WriteLine(divisibleBy7And5);
    }
}