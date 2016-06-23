using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while(command != "End")
            {
                string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                if(!persons.Any(p => p.name == personName))
                {
                    persons.Add(new Person(personName));
                }

                string action = tokens[1];
                Person person = persons.Where(p => p.name == personName).First();
                switch(action)
                {
                    case "company":
                        string companyName = tokens[2];
                        string department = tokens[3];
                        decimal salary = decimal.Parse(tokens[4]);
                        person.company = new Company(companyName, department, salary);
                        break;
                    case "pokemon":
                        string pokemonName = tokens[2];
                        string pokemonType = tokens[3];
                        person.pokemons.Add(new Pokemon(pokemonName, pokemonType));
                        break;
                    case "parents":
                        string parentName = tokens[2];
                        string parentBirthday = tokens[3];
                        person.parents.Add(new Parent(parentName, parentBirthday));
                        break;
                    case "children":
                        string childName = tokens[2];
                        string childBirthday = tokens[3];
                        person.children.Add(new Child(childName, childBirthday));
                        break;
                    case "car":
                        string model = tokens[2];
                        int speed = int.Parse(tokens[3]);
                        person.car = new Car(model, speed);
                        break;
                }

                command = Console.ReadLine();
            }

            string perName = Console.ReadLine();


            
            Person pers = persons.Where(p => p.name == perName).First();

            Console.WriteLine(pers.name);
            Console.WriteLine("Company:");
            if (pers.company != null)
            {
                Console.WriteLine(pers.company);
            }
            Console.WriteLine("Car:");
            if(pers.car != null)
            {
                Console.WriteLine(pers.car);
            }
            Console.WriteLine("Pokemon:");
            pers.pokemons.ForEach(p => Console.WriteLine(p));
            Console.WriteLine("Parents:");
            pers.parents.ForEach(p => Console.WriteLine(p));
            Console.WriteLine("Children:");
            pers.children.ForEach(c => Console.WriteLine(c));
        }
    }
}
