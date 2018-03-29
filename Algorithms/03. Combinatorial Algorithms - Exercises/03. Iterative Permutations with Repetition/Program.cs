using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string input = String.Join("", Console.ReadLine().Split());

        foreach(var permutation in GetPermutations(input))
        {
            Console.WriteLine(String.Join(" ", permutation.ToCharArray().Reverse()));
        }
    }

    private static IEnumerable<string> GetPermutations(string input)
    {
        HashSet<string> results = new HashSet<string>();
        HashSet<string> partials = new HashSet<string>();

        foreach(char c in input.ToCharArray())
        {
            List<string> current = new List<string>();
            string charToAdd = c.ToString();
            foreach(string s in partials)
            {
                for(int i=0; i<=s.Length; i++)
                {
                    string newWord = s.Substring(0, i) + charToAdd + s.Substring(i);
                    if(newWord.Length == input.Length)
                    {
                        results.Add(newWord);
                    }
                    else
                    {
                        current.Add(newWord);
                    }
                }
            }

            partials.Add(charToAdd);

            foreach(var h in current)
            {
                partials.Add(h);
            }
        }

        return results;
    }
}