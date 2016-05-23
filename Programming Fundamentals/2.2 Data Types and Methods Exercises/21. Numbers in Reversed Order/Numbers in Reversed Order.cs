using System;

class ReverseNumber
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());
        Console.WriteLine(GetReversedNumber(number));
    }

    static double GetReversedNumber(double number)
    {
        string numberAsAString = number.ToString();
        string reversedNymberAsAString = string.Empty;
        if (number < 0)
        {
            reversedNymberAsAString += '-'; //in case the number is negative
        }
        for (int i = numberAsAString.Length - 1; i >= 0; i--)
        {
            if (number < 0 && i == 0)
            {
                continue;
            }
            char digitOrPoint = numberAsAString[i];
            reversedNymberAsAString += digitOrPoint;
        }

        double reversedNumber = double.Parse(reversedNymberAsAString);
        return reversedNumber;
    }
}
