using System;

class CategorizeNumbersandFindMinMaxAverage
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        double[] doubles = new double[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            doubles[i] = double.Parse(numbers[i]);
        }

        int integerCounter=0;
        int doubleCounter = 0;
        foreach(double floating in doubles)
        {
            if(floating % 1 == 0)
            {
                integerCounter++;
            }
            else
            {
                doubleCounter++;
            }
        }

        double[] intArr = new double[integerCounter];
        int intIndex = 0;
        double[] doubleArr = new double[doubleCounter];
        int doubleIndex = 0;

        foreach(double floating in doubles)
        {
            if(floating %1 == 0)
            {
                intArr[intIndex] = floating;
                intIndex++;
            }
            else
            {
                doubleArr[doubleIndex] = floating;
                doubleIndex++;
            }
        }
        
        double intMin=intArr[0];
        double intMax=intArr[0];
        double intSum=0;
        double doubleMin = doubleArr[0];
        double doubleMax = doubleArr[0];
        double doubleSum = 0;

        foreach(double integer in intArr)
        {
            if(integer<intMin)
            {
                intMin = integer;
            }
            if(integer>intMax)
            {
                intMax = integer;
            }
            intSum += integer;
        }

        foreach(double floating in doubleArr)
        {
            if(floating<doubleMin)
            {
                doubleMin = floating;
            }
            if(floating>doubleMax)
            {
                doubleMax = floating;
            }
            doubleSum += floating;
        }

        Console.WriteLine();

        Console.WriteLine("[" + String.Join(", ", doubleArr) + "] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", doubleMin, doubleMax, doubleSum, doubleSum / doubleArr.Length);

        Console.WriteLine();

        Console.WriteLine("[" + String.Join(", ", intArr) + "] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", intMin, intMax, intSum, (double)intSum / intArr.Length);
    }
}