using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int max = GetMax(num1, num2);
            max = GetMax(max, num3);
            Console.WriteLine(max);
        }

        static int GetMax(int a, int b)
        {
            return a >= b ? a : b;
        }
    }
}
