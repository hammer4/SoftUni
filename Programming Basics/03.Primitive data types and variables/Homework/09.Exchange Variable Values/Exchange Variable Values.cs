using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5, b = 10, c;
        Console.WriteLine("a= " + a + ";b= " + b);
        c = a;
        a = b;
        b = c;
        Console.WriteLine("a= " + a + ";b= " + b);
    }
}
