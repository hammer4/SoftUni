using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Number_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            DecimalNumber number = new DecimalNumber(Console.ReadLine());
            Console.WriteLine(number.NumberReversed());
        }
    }
}
