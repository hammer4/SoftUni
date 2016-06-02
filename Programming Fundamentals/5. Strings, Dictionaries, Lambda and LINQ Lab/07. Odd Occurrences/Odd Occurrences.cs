using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach(string word in words)
            {
                if(dictionary.ContainsKey(word.ToLower()))
                {
                    dictionary[word.ToLower()]++;
                }
                else
                {
                    dictionary[word.ToLower()] = 1;
                }
            }

            List<string> result = new List<string>();
            foreach(var key in dictionary.Keys)
            {
                if(dictionary[key] %2 == 1)
                {
                    result.Add(key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
