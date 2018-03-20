using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int key = int.Parse(Console.ReadLine());
        Console.WriteLine(IndexOf(arr, key));
    }

    public static int IndexOf(int[] arr, int key)
    {
        int lo = 0;
        int hi = arr.Length - 1;

        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;

            if (key < arr[mid])
            {
                hi = mid - 1;
            }
            else if (key > arr[mid])
            {
                lo = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}