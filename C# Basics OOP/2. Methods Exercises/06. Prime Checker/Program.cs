using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            bool isPrime = true;
            if(number == 0 || number == 1 || number == 2)
            {
                isPrime = true;
            }
            else
            {
                for(int i=2; i<=Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }

            Number num = new Number(number, isPrime);
            num.GetNextPrime();
            Console.WriteLine("{0}, {1}", num.GetNextPrime(), num.isPrime ? "true" : "false");
        }
    }
}
