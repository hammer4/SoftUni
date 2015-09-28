using System;

class SortArrayofNumbersUsingSelectionSort
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

        for(int i=0; i<integers.Length-1; i++)
        {
            int minimalElementIndex = i;
            for(int j=i+1; j<integers.Length; j++)
            {
                if (integers[j] < integers[minimalElementIndex])
                {
                    minimalElementIndex = j;
                }
            }
            if(minimalElementIndex != i)
            {
                int changer = integers[minimalElementIndex];
                integers[minimalElementIndex] = integers[i];
                integers[i] = changer;
            }
        }

        Console.WriteLine(String.Join(" ", integers));


    }
}