using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Occurrences_in
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();
            int occurences = 0;
            int index = -1;

            while(text.IndexOf(pattern, index+1) != -1)
            {
                occurences++;
                index = text.IndexOf(pattern, index + 1);
            }

            Console.WriteLine(occurences);
        }
    }
}
