using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        string input = Console.ReadLine();

        foreach(var ch in input)
        {
            if (!dictionary.ContainsKey(ch))
            {
                dictionary.Add(ch, 0);
            }

            dictionary[ch]++;
        }

        foreach(var key in dictionary.Keys.OrderBy(k => k))
        {
            Console.WriteLine($"{key}: {dictionary[key]} time/s");
        }
    }
}