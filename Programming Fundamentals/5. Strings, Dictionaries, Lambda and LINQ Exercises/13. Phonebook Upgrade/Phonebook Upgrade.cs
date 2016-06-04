using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Phonebook_Upgrade
{
    class PhonebookUpgrade
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Trim().Split(' ');
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "A":
                        phonebook[command[1]] = command[2];
                        break;
                    case "S":
                        if (phonebook.ContainsKey(command[1]))
                        {
                            Console.WriteLine("{0} -> {1}", command[1], phonebook[command[1]]);
                        }
                        else
                        {
                            Console.WriteLine("Contact {0} does not exist.", command[1]);
                        }
                        break;
                    case "ListAll":
                        foreach(var key in phonebook.Keys.OrderBy(x => x))
                        {
                            Console.WriteLine("{0} -> {1}", key, phonebook[key]);
                        }
                        break;
                }
                command = Console.ReadLine().Split(' ');
            }
        }
    }
}
