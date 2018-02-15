using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();
        string command;

        while((command = Console.ReadLine()) != "Tournament")
        {
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            if(!trainers.Any(t => t.Name == trainerName))
            {
                trainers.Add(new Trainer(trainerName));
            }

            Trainer trainer = trainers.First(t => t.Name == trainerName);

            trainer.AddPokemon(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }

        while((command = Console.ReadLine()) != "End")
        {
            foreach(var trainer in trainers)
            {
                if(trainer.Pokemons.Any(p => p.Element == command))
                {
                    trainer.IncreaseBadges();
                }
                else
                {
                    trainer.ReducePokemonsHealth();
                    trainer.RemoveDead();
                }
            }
        }

        trainers
            .OrderByDescending(t => t.Badges)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}