using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        do
        {
            string[] data = input.Split('-');
            if (dictionary.ContainsKey(data[0]))
            {
                dictionary[data[0]].Add(data[1]);
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(data[1]);
                dictionary.Add(data[0], list);
            }
            input = Console.ReadLine();
        } while (input != "search");

        input = Console.ReadLine();

        while (input != "") //this is not mentioned in the homework
        {
            if (dictionary.ContainsKey(input))
            {
                foreach (string number in dictionary[input])
                {
                    Console.WriteLine("{0} -> {1}", input, number);
                }
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", input);
            }
            input = Console.ReadLine();
        }
    }
}