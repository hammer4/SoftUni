using System;
using System.IO;

class OddEvenElements
{
    static void Main()
    {
        byte[] inputBuffer = new byte[16000];
        Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
        Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
        string inputLine = Console.ReadLine();
        string[] numbers = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        decimal oddSum = 0;
        decimal oddMin = decimal.MaxValue;
        decimal oddMax = decimal.MinValue;
        decimal evenSum = 0;
        decimal evenMin = decimal.MaxValue;
        decimal evenMax = decimal.MinValue;
        for(int i=0; i<=numbers.Length-1; i++)
        {
            if(i%2 == 0)
            {
                decimal number = decimal.Parse(numbers[i]);
                if (number < oddMin)
                    oddMin = number;
                if (number > oddMax)
                    oddMax = number;
                oddSum += number;
            }
            else
            {
                decimal number = decimal.Parse(numbers[i]);
                if (number < evenMin)
                    evenMin = number;
                if (number > evenMax)
                    evenMax = number;
                evenSum += number;
            }
        }

        if (numbers.Length == 0)
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        else if (numbers.Length == 1)
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum=No, EvenMin=No, EvenMax=No", (double)oddSum, (double)oddMin, (double)oddMax);
        else
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}", (double)oddSum, (double)oddMin, (double)oddMax, (double)evenSum, (double)evenMin, (double)evenMax);
    }
}