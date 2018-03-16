using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Quick
{
    public static void Sort<T>(T[] arr) where T : IComparable
    {
        Shuffle(arr);
        Sort(arr, 0, arr.Length - 1);
    }

    private static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable
    {
        if(lo >= hi)
        {
            return;
        }

        int pivot = Partition(arr, lo, hi);
        Sort(arr, lo, pivot - 1);
        Sort(arr, pivot + 1, hi);
    }

    private static int Partition<T>(T[] arr, int lo, int hi) where T : IComparable
    {
        if(lo >= hi)
        {
            return lo;
        }

        int i = lo;
        int j = hi + 1;

        while (true)
        {
            while(Less(arr[++i], arr[lo]))
            {
                if(i == hi)
                {
                    break;
                }
            }

            while(Less(arr[lo], arr[--j]))
            {
                if(j == lo)
                {
                    break;
                }
            }

            if(i >= j)
            {
                break;
            }

            Swap(arr, i, j);
        }

        Swap(arr, lo, j);
        return j;
    }

    private static void Swap<T>(T[] arr, int first, int second)
    {
        var temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }

    private static bool Less<T>(T current, T other) where T : IComparable
    {
        return current.CompareTo(other) < 0;
    }

    private static void Shuffle<T>(T[] source)
    {
        Random rnd = new Random();

        for (int i = 0; i < source.Length; i++)
        {
            // Exchange array[i] with random element in array[i … n-1]

            int r = i + rnd.Next(0, source.Length - i);

            T temp = source[i];
            source[i] = source[r];
            source[r] = temp;
        }
    }
}