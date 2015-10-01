using System;

class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double thirdNum = double.Parse(Console.ReadLine());
        double fourthNum = double.Parse(Console.ReadLine());
        double fifthNum = double.Parse(Console.ReadLine());
        double max = int.MinValue;

        if (firstNum > max)
        {
            max = firstNum;
        }
        if (secondNum>max)
        {
            max = secondNum;
        }
        if (thirdNum>max)
        {
            max = thirdNum;
        }
        if (fourthNum>max)
        {
            max = fourthNum;
        }
        if (fifthNum>max)
        {
            max = fifthNum;
        }
        Console.WriteLine(max);
    }
}