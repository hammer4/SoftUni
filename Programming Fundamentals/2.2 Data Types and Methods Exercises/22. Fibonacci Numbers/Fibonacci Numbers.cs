using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if(number == 0)
            {
                Console.WriteLine("1");
                return;
            }
            else if(number == 1)
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.WriteLine(nthFibonaccinumber(number));
            }
        }

        static int nthFibonaccinumber(int num)
        {
            int a = 1;
            int b = 1;
            int c;
            for (int i = 2; i <= num; i++)
            {
                c = a + b;
                a = b;
                b = c;
                if(i == num)
                {
                    return c;
                }
            }

            return 0;
        }
    }
}
