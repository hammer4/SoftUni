using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Last_Digit_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number(int.Parse(Console.ReadLine()));
            Console.WriteLine(number.LastDigitName());
        }
    }
}
