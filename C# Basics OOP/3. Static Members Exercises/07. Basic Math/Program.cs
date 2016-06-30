using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Basic_Math
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                double num1 = double.Parse(tokens[1]);
                double num2 = double.Parse(tokens[2]);

                switch(tokens[0])
                {
                    case "Sum": Console.WriteLine("{0:F2}", MathUtil.Sum(num1, num2)); break;
                    case "Subtract": Console.WriteLine("{0:F2}", MathUtil.Subtract(num1, num2)); break;
                    case "Multiply": Console.WriteLine("{0:F2}", MathUtil.Multiply(num1, num2)); break;
                    case "Divide": Console.WriteLine("{0:F2}", MathUtil.Divide(num1, num2)); break;
                    case "Percentage": Console.WriteLine("{0:F2}", MathUtil.Percentage(num1, num2)); break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
