using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array = new char[26];

            int i = 0;
            char ch = 'a';
            for (; i<array.Length; i++, ch++)
            {
                array[i] = ch;
            }

            string input = Console.ReadLine();
            for(i=0; i<input.Length; i++)
            {
                for(int j=0; j<array.Length; j++)
                {
                    if(input[i] == array[j])
                    {
                        Console.WriteLine(input[i] + " -> " + j);
                    }
                }
            }
        }
    }
}
