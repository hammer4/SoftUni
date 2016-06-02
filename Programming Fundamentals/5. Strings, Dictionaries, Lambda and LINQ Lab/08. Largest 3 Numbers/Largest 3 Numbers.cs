using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            List<double> result = numbers.OrderByDescending(x => x).Take(3).ToList();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
