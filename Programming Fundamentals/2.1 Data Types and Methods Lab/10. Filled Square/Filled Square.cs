using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintHeaderRow(num);

            for (int i=0; i<num-2; i++)
            {
                PrintMiddleRow(num);
            }

            PrintHeaderRow(num);
        }

        static void PrintHeaderRow(int num)
        {
            Console.WriteLine(new String('-', num*2));
        }

        static void PrintMiddleRow(int num)
        {
            Console.Write("-");

            for (int i=0; i<num-1; i++)
            {
                Console.Write("\\/");
            }

            Console.WriteLine("-");
        }
    }
}
