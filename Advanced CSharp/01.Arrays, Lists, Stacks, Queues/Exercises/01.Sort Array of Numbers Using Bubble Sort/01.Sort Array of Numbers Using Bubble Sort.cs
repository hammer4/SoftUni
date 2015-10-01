using System;
using System.Collections.Generic;
using System.Linq;

class ArrayofNumbersUsingBubbleSort
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        int[] integers = numbers.Select(int.Parse).ToArray();
        BubbleSort(integers);
        Console.WriteLine(String.Join(", ", integers));
    }

    static int[] BubbleSort(int[] unsortedArray)
    {
        int sortedElements=0;
        for(int i=0; i<unsortedArray.Length-1; i++)
        {
            bool arrayIsSorted = true;
            for(int j=0; j<unsortedArray.Length-sortedElements-1; j++)
            {
                if (unsortedArray[j] > unsortedArray[j + 1])
                {
                    int changer = unsortedArray[j];
                    unsortedArray[j] = unsortedArray[j + 1];
                    unsortedArray[j + 1] = changer;
                    arrayIsSorted = false;
                }
            }
            if (arrayIsSorted)
            {
                break;
            }
            sortedElements++;
        }
        return unsortedArray;
    }
}
