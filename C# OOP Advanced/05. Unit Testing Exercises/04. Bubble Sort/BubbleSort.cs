using System;
using System.Collections.Generic;
using System.Text;

public class BubbleSort
{
    public BubbleSort(int[] array)
    {
        this.Array = array;
    }

    public int[] Array { get; private set; }

    public void Sort()
    {
        int temp = 0;

        for (int write = 0; write < Array.Length; write++)
        {
            for (int sort = 0; sort < Array.Length - 1; sort++)
            {
                if (Array[sort] > Array[sort + 1])
                {
                    temp = Array[sort + 1];
                    Array[sort + 1] = Array[sort];
                    Array[sort] = temp;
                }
            }
        }
    }
}