using System;

class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double thirdNum = double.Parse(Console.ReadLine());
        double biggest, middle, least;

        if (firstNum >= secondNum && firstNum >= thirdNum)
        {
            biggest = firstNum;
            if (secondNum >= thirdNum)
            {
                middle = secondNum;
                least = thirdNum;
            }
            else
            {
                middle = thirdNum;
                least = secondNum;
            }
        }
        else if (secondNum >= firstNum && secondNum >= thirdNum)
        {
            biggest = secondNum;

            if (firstNum >= thirdNum)
            {
                middle = firstNum;
                least = thirdNum;
            }
            else
            {
                middle = thirdNum;
                least = firstNum;
            }
        }
        else
        {
            biggest = thirdNum;
            if (firstNum >= secondNum)
            {
                middle = firstNum;
                least = secondNum;
            }
            else
            {
                middle = secondNum;
                least = firstNum;
            }


        }
        Console.WriteLine("{0} {1} {2}", biggest, middle, least);
    }
}
