using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var dictionary = new Dictionary<string, int>();

        dictionary.Add("abc", 5);
        dictionary.Add("abcd", 10);
        dictionary.Add("abce", 15);
        dictionary.Add("abcf", 20);

        foreach(var kvp in dictionary.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key}, {kvp.Value}");
        }
    }
}