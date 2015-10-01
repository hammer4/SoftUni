using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        Console.Write("How many elements will the array contain? : ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        Console.WriteLine("Enter the elements of the array, one at a line :");

        for(int i=0; i<array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        
        Console.WriteLine();
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(array));
    }

    static int GetIndexOfFirstElementLargerThanNeighbours(int[] array)
    {
        if(array[0]>array[1])
        {
            return 0;
        }

        for(int i=1; i<array.Length -1; i++)
        {
            if(array[i]>array[i-1] && array[i]>array[i+1])
            {
                return i;
            }
        }

        if(array[array.Length-1] > array[array.Length-2])
        {
            return array.Length - 1;
        }
        else
        {
            return -1;
        }
    }
}