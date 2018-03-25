using System;
using System.Collections.Generic;
using System.Text;

public class ArrayCreator
{
    public static T[] Create<T>(int length, T element)
    {
        var array = new T[length];

        for(int i=0; i<length; i++)
        {
            array[i] = element;
        }

        return array;
    }
}