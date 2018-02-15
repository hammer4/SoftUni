using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();

        string command;

        while((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();

            switch (tokens[0])
            {
                case "Siamese":
                    cats.Add(new Siamese(tokens[1], int.Parse(tokens[2])));
                    break;
                case "Cymric":
                    cats.Add(new Cymric(tokens[1], double.Parse(tokens[2])));
                    break;
                case "StreetExtraordinaire":
                    cats.Add(new StreetExtraordinaire(tokens[1], int.Parse(tokens[2])));
                    break;
            }
        }

        string catName = Console.ReadLine();

        var cat = cats.Single(c => c.Name == catName);

        Console.WriteLine(cat);
    }
}
