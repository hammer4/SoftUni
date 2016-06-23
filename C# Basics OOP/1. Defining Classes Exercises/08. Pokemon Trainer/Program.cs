using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (command != "Tournament")
            {
                string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                if (!trainers.Any(t => t.name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }



                var trainer = trainers.First(t => t.name == trainerName);
                trainer.pokemons.Add(new Pokemon(pokemonName, element, health));


                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.pokemons.Any(p => p.element == command))
                    {
                        trainer.badges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.pokemons)
                        {
                            pokemon.health -= 10;
                        }

                        trainer.pokemons = trainer.pokemons.Where(p => p.health > 0).ToList();
                    }
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.badges))
            {
                Console.WriteLine("{0} {1} {2}", trainer.name, trainer.badges, trainer.pokemons.Count);
            }
        }
    }
}
