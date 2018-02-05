using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, string, bool> startsWith = (a, b) => a.StartsWith(b);
            Func<string, string, bool> endsWith = (a, b) => a.EndsWith(b);
            Func<string, int, bool> checkLength = (a, b) => a.Length == b;

            Func<List<string>, List<string>, List<string>> doublePeople = (a, b) =>
            {
                foreach (string doubled in b)
                {
                    for (int i = 0; i < a.Count * 2; i++)
                    {
                        if (i < a.Count)
                        {
                            if (a[i] == doubled)
                            {
                                a.Insert(i, doubled);
                                i++;
                            }
                        }
                    }
                }

                return a;
            };

            var filtered = new List<string>();

            string command;

            while((command = Console.ReadLine()) != "Party!")
            {
                var commandArgs = command.Split();
                switch (commandArgs[1])
                {
                    case "StartsWith":
                        filtered = people
                            .Where(p => startsWith(p, commandArgs[2]))
                            .Distinct()
                            .ToList();
                        break;
                    case "EndsWith":
                        filtered = people
                            .Where(p => endsWith(p, commandArgs[2]))
                            .Distinct()
                            .ToList();
                        break;
                    case "Length":
                        filtered = people
                            .Where(p => checkLength(p, int.Parse(commandArgs[2])))
                            .Distinct()
                            .ToList();
                        break;
                }

                switch (commandArgs[0])
                {
                    case "Remove":
                        people = people
                            .Where(p => !filtered.Contains(p))
                            .ToList();
                        break;
                    case "Double":
                        people = doublePeople(people, filtered);
                        break;
                }
            }

            if(people.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
