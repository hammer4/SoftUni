using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        string command;

        while((command = Console.ReadLine()) != "Beast!")
        {
            var tokens = Console.ReadLine().Split();

            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var gender = tokens[2];

            try
            {
                switch (command)
                {
                    case "Cat":
                        animals.Add(new Cat(name, age, gender)); break;
                    case "Dog":
                        animals.Add(new Dog(name, age, gender)); break;
                    case "Frog":
                        animals.Add(new Frog(name, age, gender)); break;
                    case "Kitten":
                        animals.Add(new Kitten(name, age, gender)); break;
                    case "Tomcat":
                        animals.Add(new Tomcat(name, age, gender)); break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        animals.ForEach(a => Console.WriteLine(a));
    }
}
