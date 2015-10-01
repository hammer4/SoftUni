using System;

class ExchangeIfGreater
{
    static void Main()
    {
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double exchange;
        if (firstNum>secondNum)
        {
            exchange = firstNum;
            firstNum = secondNum;
            secondNum = exchange;
        }
        Console.WriteLine("{0} {1}", firstNum, secondNum);
    }
}
