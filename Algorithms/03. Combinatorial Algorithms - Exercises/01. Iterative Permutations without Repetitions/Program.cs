using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static char[] arr;
    private static int[] permSwappings;

    static void Main()
    {
        arr = Console.ReadLine()
             .Split()
             .Select(Char.Parse)
             .ToArray();

        permSwappings = Enumerable.Range(0, arr.Length).ToArray();

        var perm = Next();

        while(perm != null)
        {
            Console.WriteLine(String.Join(" ", perm));
            perm = Next();
        }
    }

    private static char[] Next()
    {
        if (arr == null)
        {
            return null;
        }

        char[] res = new char[arr.Length];
        Array.Copy(arr, res, arr.Length);

        int i = permSwappings.Length - 1;

        while(i >= 0 && permSwappings[i] == arr.Length - 1)
        {
            Swap(i, permSwappings[i]);
            permSwappings[i] = i;
            i--;
        }

        if(i < 0)
        {
            arr = null;
        }
        else
        {
            int prev = permSwappings[i];
            Swap(i, prev);
            int next = prev + 1;
            permSwappings[i] = next;
            Swap(i, next);
        }

        return res;
    }

    private static void Swap(int i, int v)
    {
        char temp = arr[i];
        arr[i] = arr[v];
        arr[v] = temp;
    }
}