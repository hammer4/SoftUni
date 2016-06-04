using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string result = new string(str.ToCharArray().Reverse().ToArray());
            Console.WriteLine(result);
        }
    }
}
