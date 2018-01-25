using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<long[]> list = new List<long[]>();
            list.Add(new long[] { 1, 1 });
            list.Add(new long[] { 2, 1 });
            long result = Fibonacci(n, list);
            Console.WriteLine(result);
        }

        private static long Fibonacci(int n, List<long[]> list)
        {
            if(list.Any(x => x[0] == n))
            {
                return list.First(x => x[0] == n)[1];
            }
            else
            {
                var result = Fibonacci(n - 1, list) + Fibonacci(n - 2, list);
                list.Add(new long[] { n, result });
                return Fibonacci(n - 1, list) + Fibonacci(n - 2, list);
            }

        }
    }
}
