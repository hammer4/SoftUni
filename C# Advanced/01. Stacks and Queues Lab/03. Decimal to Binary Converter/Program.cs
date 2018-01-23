using System;
using System.Collections.Generic;

namespace _03._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDecimal = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if(numberDecimal == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while(numberDecimal > 0)
            {
                stack.Push(numberDecimal % 2);
                numberDecimal /= 2;
            }

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
