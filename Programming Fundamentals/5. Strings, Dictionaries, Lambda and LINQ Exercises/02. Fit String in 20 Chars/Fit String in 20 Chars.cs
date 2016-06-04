using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Fit_String_in_20
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            if(str.Length<20)
            {
                Console.WriteLine(str.PadRight(20,'*'));
            }
            else
            {
                Console.WriteLine(str.Substring(0, 20));
            }
        }
    }
}
