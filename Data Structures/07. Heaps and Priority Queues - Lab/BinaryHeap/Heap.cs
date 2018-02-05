using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        int n = arr.Length;

        for(int i=n/2; i>=0; i--)
        {
            Down(arr, i, n);
        }

        for(int i= n-1; i>=0; i--)
        {
            Swap(arr, 0, i);
            Down(arr, 0, i);
        }
    }

    private static void Down(T[] arr, int index, int border)
    {
        while (index < border / 2)
        {
            int child = Left(index);

            if (child + 1 < border && IsLess(arr, child, child + 1))
            {
                child = child + 1;
            }

            if (IsLess(arr, child, index))
            {
                break;
            }

            Swap(arr, index, child);
            index = child;
        }
    }

    private static int Left(int index)
    {
        return index * 2 + 1;
    }

    private static void Swap(T[] arr, int index, int other)
    {
        T temp = arr[index];
        arr[index] = arr[other];
        arr[other] = temp;
    }

    private static bool IsLess(T[] arr, int other, int index)
    {
        return arr[other].CompareTo(arr[index]) < 0;
    }
}
