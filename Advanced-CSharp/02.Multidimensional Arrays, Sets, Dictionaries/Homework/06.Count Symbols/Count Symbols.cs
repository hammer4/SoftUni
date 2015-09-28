using System;
using System.Collections.Generic;

class CountSymbols
{
    static void Main(string[] args)
    {
        SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
        string input = Console.ReadLine();
        
        foreach(char character in input)
        {
            if (dictionary.ContainsKey(character))
            {
                dictionary[character] += 1;
            }
            else
            {
                dictionary.Add(character, 1);
            }
        }

        foreach(KeyValuePair<char, int> keyvalue in dictionary)
        {
            Console.WriteLine("{0}: {1} time/s", keyvalue.Key, keyvalue.Value);
        }
    }
}