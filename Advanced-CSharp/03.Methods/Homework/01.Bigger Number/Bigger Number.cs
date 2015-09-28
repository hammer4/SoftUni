using System;

class BiggerNumber
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(firstNumber, secondNumber));
    }

    static int GetMax(int firstNumber, int secondNumber)
    {
        int maxNumber = firstNumber;
        if(secondNumber>maxNumber)
        {
            maxNumber = secondNumber;
        }
        return maxNumber;
    }
}