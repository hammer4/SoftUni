using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? integer = null;
        double? floating = null;
        Console.WriteLine(integer);
        Console.WriteLine(floating);
        integer += 10;
        floating += 2.354;
        Console.WriteLine(integer);
        Console.WriteLine(floating);
    }
}
