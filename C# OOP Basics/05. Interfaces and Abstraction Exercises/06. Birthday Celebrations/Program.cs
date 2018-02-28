using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IBirthable> all = new List<IBirthable>();

        string command;

        while((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();

            switch (tokens[0])
            {
                case "Citizen":
                    all.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                    break;
                case "Pet":
                    all.Add(new Pet(tokens[1], tokens[2]));
                    break;
            }
        }

        int year = int.Parse(Console.ReadLine());

        all.Where(c => c.Birthdate.Year == year)
            .Select(c => c.Birthdate)
            .ToList()
            .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));
    }
}
