using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SoftUni_Coffee_Supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] delimiters = Console.ReadLine().Split(' ');
            Dictionary<string, long> coffees = new Dictionary<string, long>();
            Dictionary<string, string> members = new Dictionary<string, string>();
            string command = Console.ReadLine();
            while (command != "end of info")
            {
                if(command.Contains(delimiters[0]))
                {
                    string[] tokens = command.Split(new[] { delimiters[0] }, StringSplitOptions.RemoveEmptyEntries);
                    string member = tokens[0];
                    string coffeeType = tokens[1];
                    members[member] = coffeeType;
                }
                else if(command.Contains(delimiters[1]))
                {
                    string[] tokens = command.Split(new[] { delimiters[1] }, StringSplitOptions.RemoveEmptyEntries);
                    string coffeeType = tokens[0];
                    long quantity = 0;

                    if (tokens.Length > 1)
                    {
                        quantity = long.Parse(tokens[1]);
                    }

                    if (coffees.ContainsKey(coffeeType))
                    {
                        coffees[coffeeType] += quantity;
                    }
                    else
                    {
                        coffees[coffeeType] = quantity;
                    }
                }

                command = Console.ReadLine();
            }

            foreach(var pair in coffees)
            {
                if(pair.Value <= 0)
                {
                    Console.WriteLine("Out of {0}", pair.Key);
                }
            }

            foreach(var pair in members)
            {
                if(!coffees.ContainsKey(pair.Value))
                {
                    Console.WriteLine("Out of {0}", pair.Value);
                }
            }

            command = Console.ReadLine();

            while(command != "end of week")
            {
                string[] tokens = command.Split(' ');
                string name = tokens[0];
                long quantity = long.Parse(tokens[1]);
                string coffeeType = members[name];
                coffees[coffeeType] -= quantity;
                if(coffees[coffeeType] <= 0)
                {
                    Console.WriteLine("Out of {0}", coffeeType);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Coffee Left:");

            foreach(var pair in coffees.Where(c => c.Value > 0).OrderByDescending(c => c.Value))
            {
                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("For:");

            foreach(var pair in members.OrderBy(m => m.Value).ThenByDescending(m => m.Key))
            {
                if (coffees.ContainsKey(pair.Value))
                {
                    if (coffees[pair.Value] > 0)
                    {
                        Console.WriteLine("{0} {1}", pair.Key, pair.Value);
                    }
                }
            }
        }
    }
}
