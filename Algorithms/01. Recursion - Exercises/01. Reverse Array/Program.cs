using System;
using System.Collections.Generic;
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

        Reverse(arr, 0, arr.Length - 1);

        Console.WriteLine(String.Join(" ", arr));
    }

    static void Reverse(int[] arr, int start, int end)
    {
        if(start >= end)
        {
            return;
        }

        int temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;

        Reverse(arr, start + 1, end - 1);
    }
}