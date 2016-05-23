using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _26.Factorial
{
    class Factorial
    {
        static void Main(string[] args)
        {
            BigInteger factorial = 1;
            int number = int.Parse(Console.ReadLine());

            while(number > 0)
            {
                factorial *= number;
                number--;
            }

            Console.WriteLine(factorial);
        }
    }
}
