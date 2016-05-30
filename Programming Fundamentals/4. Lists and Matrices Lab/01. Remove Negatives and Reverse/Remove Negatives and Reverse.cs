using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> result = new List<int>();

            foreach(int number in list)
            {
                if(number >= 0)
                {
                    result.Add(number);
                }
            }

            result.Reverse();
            if (result.Count > 0)
            {
                Console.WriteLine(String.Join(" ", result));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
