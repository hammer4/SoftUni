using System;

class TheBiggestOf3Numbers
{
    static void Main()
    {
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double thirdNum = double.Parse(Console.ReadLine());

        if (firstNum >= secondNum)
        {
            if (firstNum>= thirdNum)
            {
                Console.WriteLine(firstNum);
            }
            else
            {
                Console.WriteLine(thirdNum);
            }
        }
        else
        {
            if (secondNum >= thirdNum)
            {
                Console.WriteLine(secondNum);
            }
            else
            {
                Console.WriteLine(thirdNum);
            }
        }
    }
}
