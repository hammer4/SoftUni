using System;

class PracticeNullableTypes
{
    static void Main()
    {
        int? num = null;
        Console.WriteLine(num);
        num += 42;
        Console.WriteLine(num);
        num = 10;
        Console.WriteLine(num);
    }
}