using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Reverse_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array = new char[3];

            for(int i=0; i<array.Length; i++)
            {
                array[i] = char.Parse(Console.ReadLine());
            }

            Array.Reverse(array);
            string str = new string(array);
            Console.WriteLine(str);
        }
    }
}
