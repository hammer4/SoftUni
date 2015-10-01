using System;
using System.Collections.Generic;

class LargerThanNeighbours
{
    static void Main()
    {
        Console.Write("How many elements will the set be consisted of? : ");
        int capacity = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        Console.WriteLine("Enter the value of each element on a new line: ");

        for(int i =0; i<capacity; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine();
        for(int i=0; i<list.Count; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(list, i));
        }
    }

    static bool IsLargerThanNeighbours(List<int> list, int i)
    {
        if(i>0 && i<list.Count-1)
        {
            if(list[i]>list[i-1] && list[i]>list[i+1])
            {
                return true;
            }
        }
        else if(i==0)
        {
            if(list[i] > list[i+1])
            {
                return true;
            }
        }
        else
        {
            if(list[i]>list[i-1])
            {
                return true;
            }
        }

        return false;
    }
}