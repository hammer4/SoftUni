using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            List<int> primes = GetPrimes(start, end);
            Console.WriteLine(string.Join(", ", primes));
        }

        static List<int> GetPrimes(int start, int end)
        {
            List<int> list = new List<int>();
            for(int i=start;i<=end; i++)
            {
                if(IsPrime(i))
                {
                    list.Add(i);
                }
            }

            return list;
        }

        static bool IsPrime(int number)
        {
            bool isPrime = true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}
