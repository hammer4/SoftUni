using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Reverse_an_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ');
            for(int i=0; i<array.Length/2; i++)
            {
                string changer = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = changer;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
