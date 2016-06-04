using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string[] sentences = Console.ReadLine().Split(new[] { '.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string sentence in sentences)
            {
                string[] words = Regex.Split(sentence, "[^A-Za-z]");
                if(words.Contains(word))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
