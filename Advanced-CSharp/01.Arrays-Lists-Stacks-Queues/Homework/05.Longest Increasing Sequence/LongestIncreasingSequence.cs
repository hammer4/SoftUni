using System;

class LongestIncreasingSequence
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        int[] integers = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            integers[i] = int.Parse(numbers[i]);
        }

        int counter=1;
        int longestSequence=1;
        int indexOfSequenceBeginning=0;
        for(int i=0; i<integers.Length-1; i++)
        {
            Console.Write(integers[i]);
            if(integers[i+1]>integers[i])
            {
                Console.Write(" ");
                counter++;
                if (counter>longestSequence)
                {
                    longestSequence = counter;
                    indexOfSequenceBeginning = i - longestSequence + 2;
                }
            }
            else
            {
                Console.WriteLine();
                counter = 1;
            }
        }
        Console.WriteLine(integers[integers.Length - 1]);

        if (longestSequence > 1)
        {
            Console.Write("Longest: ");
            for (int i = indexOfSequenceBeginning; i<indexOfSequenceBeginning+longestSequence; i++)
            {
                Console.Write("{0} ", integers[i]);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Longest: " + integers[0]);
        }
    }
}