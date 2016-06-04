using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.Reverse_the
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { '.', ',', ';', ':', '=', ')', '(', '&', '[', ']', '\'', '"', '\\', '/', '?', '!', ' ' };
            string text = Console.ReadLine();
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            char[] nonSeparators = String.Join("", words).ToCharArray();
            string[] punctuation = text.Split(nonSeparators, StringSplitOptions.RemoveEmptyEntries);
            words = words.Reverse().ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + punctuation[i]);
            }

            /* Another Solution
            
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { '.', ',', ';', ':', '=', ')', '(', '&', '[', ']', '\'', '"', '\\', '/', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int startIndexBegin = 0;
            int endIndex = text.Length - 1;
            for (int i=0; i<words.Length/2; i++)
            {
                string word = words[i];
                string word2 = words[words.Length - i - 1];
                StringBuilder sb = new StringBuilder(text);
                int startIndex = text.IndexOf(word, startIndexBegin);
                startIndexBegin = startIndex + 1;
                int firstlength = word.Length;
                sb.Replace(word, word2, startIndex, firstlength);
                text = sb.ToString();
                int endIndexBegin = i==0? text.Length-1 : endIndex -1 - word.Length + word2.Length;
                endIndex = text.LastIndexOf(word2, endIndexBegin);
                int secondlength = word2.Length;
                sb.Replace(word2, word, endIndex, secondlength);
                text = sb.ToString();
            }

            Console.WriteLine(text);

            */
        }
    }
}
