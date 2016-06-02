using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Print_a_Receipt
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            Console.WriteLine("/" + new string('-', 22) + "\\");
            foreach(decimal num in numbers)
            {
                Console.WriteLine("| {0,20:F2} |", num);
            }

            Console.WriteLine("|" + new string('-', 22) + "|");
            Console.WriteLine("| Total: {0,13:F2} |", numbers.Sum());
            Console.WriteLine("\\" + new string('-', 22) + "/");
        }
    }
}
