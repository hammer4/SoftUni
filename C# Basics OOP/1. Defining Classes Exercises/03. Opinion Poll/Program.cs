using _01.Define_a_class_Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Opinion_Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Person[] persons = new Person[count];

            for(int i=0; i<count; i++)
            {
                string personString = Console.ReadLine();
                string[] tokens = personString.Split(' ');
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                persons[i] = new Person(name, age);
            }

            List<Person> result = persons.OrderBy(p => p.name).Where(p => p.age > 30).ToList();

            foreach(Person person in result)
            {
                Console.WriteLine("{0} - {1}", person.name, person.age);
            }
        }
    }
}
