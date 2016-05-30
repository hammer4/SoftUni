using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(new[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lowerCaseWords = new List<string>();
            List<string> mixedCaseWords = new List<string>();
            List<string> upperCaseWords = new List<string>();

            foreach(string word in words)
            {
                if(word[0] >= 'a' && word[0] <= 'z')
                {
                    bool isMixedCase = false;
                    for(int i = 1; i<word.Length; i++)
                    {
                        if(word[i] < 'a' || word[i] > 'z')
                        {
                            isMixedCase = true;
                        }
                    }

                    if(isMixedCase)
                    {
                        mixedCaseWords.Add(word);
                    }
                    else
                    {
                        lowerCaseWords.Add(word);
                    }
                }
                else if (word[0] >= 'A' && word[0] <= 'Z')
                {
                    bool isMixedCase = false;
                    for (int i = 1; i < word.Length; i++)
                    {
                        if (word[i] < 'A' || word[i] > 'Z')
                        {
                            isMixedCase = true;
                        }
                    }

                    if (isMixedCase)
                    {
                        mixedCaseWords.Add(word);
                    }
                    else
                    {
                        upperCaseWords.Add(word);
                    }
                }
                else
                {
                    mixedCaseWords.Add(word);
                }
            }

            Console.WriteLine("Lower-case: {0}",string.Join(", ", lowerCaseWords));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCaseWords));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCaseWords));
        }
    }
}
