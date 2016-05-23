using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string result = string.Empty;

            try
            {
                sbyte.Parse(number);
                result += "* sbyte\n";
            }
            catch
            {

            }

            try
            {
                byte.Parse(number);
                result += "* byte\n";
            }
            catch
            {

            }

            try
            {
                short.Parse(number);
                result += "* short\n";
            }
            catch
            {

            }

            try
            {
                ushort.Parse(number);
                result += "* ushort\n";
            }
            catch
            {

            }

            try
            {
                int.Parse(number);
                result += "* int\n";
            }
            catch
            {

            }

            try
            {
                uint.Parse(number);
                result += "* uint\n";
            }
            catch
            {

            }

            try
            {
                long.Parse(number);
                result += "* long\n";
            }
            catch
            {
                Console.WriteLine("{0} can't fit in any type", number);
                return;
            }

            Console.WriteLine($"{number} can fit in:\n" + result);
        }
    }
}
