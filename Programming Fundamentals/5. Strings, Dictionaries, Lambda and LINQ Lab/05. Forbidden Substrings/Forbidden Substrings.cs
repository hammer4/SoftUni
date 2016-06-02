using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Forbidden_Substrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = text.Split(' ');
            string[] forbiddenWords = Console.ReadLine().Split(' ');

            foreach (string fword in forbiddenWords)
            {
                text = text.Replace(fword, new string('*', fword.Length));
            }

            Console.WriteLine(text);
        }
    }
}
