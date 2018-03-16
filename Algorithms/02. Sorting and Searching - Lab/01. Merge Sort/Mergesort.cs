using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mergesort<T> where T : IComparable
{
    private static T[] aux;

    public static void Sort(T[] arr)
    {
        aux = new T[arr.Length];
        Sort(arr, 0, arr.Length - 1);
    }

    private static void Merge(T[] arr, int lo, int mid, int hi)
    {
        if(IsLess(arr[mid], arr[mid + 1]))
        {
            return;
        }

        for(int index = lo; index < hi + 1; index++)
        {
            aux[index] = arr[index];
        }

        int i = lo;
        int j = mid + 1;

        for(int k = lo; k<=hi; k++)
        {
            if(i > mid)
            {
                arr[k] = aux[j++];
            }
            else if(j > hi)
            {
                arr[k] = aux[i++];
            }
            else if(IsLess(aux[i], aux[j]))
            {
                arr[k] = aux[i++];
            }
            else
            {
                arr[k] = aux[j++];
            }
        }
    }

    private static bool IsLess(T current, T other)
    {
        return current.CompareTo(other) < 0;
    }

    private static void Sort(T[] arr, int lo, int hi)
    {
        if(lo >= hi)
        {
            return;
        }

        int mid =  lo + (hi - lo) / 2;

        Sort(arr, lo, mid);
        Sort(arr, mid + 1, hi);
        Merge(arr, lo, mid, hi);
    }
}