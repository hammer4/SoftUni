using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
            List<string> palindromes = new List<string>();

            foreach(string word in words)
            {
                bool isPalindrome = true;

                for(int i=0; i<word.Length/2; i++)
                {
                    if(word[i] != word[word.Length - i -1])
                    {
                        isPalindrome = false;
                    }
                }

                if(isPalindrome)
                {
                    palindromes.Add(word);
                }
            }

            palindromes.Sort();
            Console.WriteLine(string.Join(", ", palindromes));
        }
    }
}
