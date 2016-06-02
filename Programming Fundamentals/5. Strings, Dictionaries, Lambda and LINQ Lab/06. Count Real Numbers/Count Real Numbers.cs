using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();

            foreach(double num in numbers)
            {
                if(dictionary.ContainsKey(num))
                {
                    dictionary[num]++;
                }
                else
                {
                    dictionary[num] = 1;
                }
            }

            foreach(var pair in dictionary)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
