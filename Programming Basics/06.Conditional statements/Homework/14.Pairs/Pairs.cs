using System;

class Pairs
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] array = input.Split(' ');
        int[] numbers = new int[array.Length];
        
        for(int i=0; i<numbers.Length; i++)
        {
            numbers[i] = int.Parse(array[i]);
        }

        bool equal = true;
        int previousPairsum;
        int currentPairSum = numbers[0] + numbers[1];
        int maxDifference = int.MinValue;

        if(numbers.Length>2)
        {
            for(int i=2; i<numbers.Length; i+=2)
            {
                currentPairSum = numbers[i] + numbers[i + 1];
                previousPairsum = numbers[i-2] + numbers[i-1];
                if(currentPairSum != previousPairsum)
                {
                    equal = false;
                    if(Math.Abs(currentPairSum-previousPairsum)>maxDifference)
                    {
                        maxDifference=Math.Abs(currentPairSum-previousPairsum);
                    }
                }

            }
        }

        if(equal)
        {
            Console.WriteLine("Yes, value={0}", currentPairSum);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDifference);
        }
    }
}
