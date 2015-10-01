using System;

class LastDigitofNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(LastDigitAsAWord(number));
    }

    static string LastDigitAsAWord(int number)
    {
        int lastDigit = Math.Abs(number % 10); //in case the number is negative
        string digitAsAWord = string.Empty;

        switch(lastDigit)
        {
            case 0: digitAsAWord = "zero"; break;
            case 1: digitAsAWord = "one"; break;
            case 2: digitAsAWord = "two"; break;
            case 3: digitAsAWord = "three"; break;
            case 4: digitAsAWord = "four"; break;
            case 5: digitAsAWord = "five"; break;
            case 6: digitAsAWord = "six"; break;
            case 7: digitAsAWord = "seven"; break;
            case 8: digitAsAWord = "eight"; break;
            case 9: digitAsAWord = "nine"; break;
         }

        return digitAsAWord;
    }
}