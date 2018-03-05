using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string command;
        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        while((command = Console.ReadLine()) != "search")
        {
            var tokens = command.Split('-');
            phonebook.AddOrReplace(tokens[0], tokens[1]);
        }

        while((command = Console.ReadLine()) != "end")
        {
            if (phonebook.ContainsKey(command))
            {
                Console.WriteLine($"{command} -> {phonebook.Get(command)}");
            }
            else
            {
                Console.WriteLine($"Contact {command} does not exist.");
            }
        }
    }
}