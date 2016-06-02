using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(' ').ToList();
            int sum = 0;
            foreach(string number in numbers)
            {
                char[] array = number.ToCharArray();
                array = array.Reverse().ToArray();
                int num = int.Parse(new string(array));
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
