using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int personsCount = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for(int i = 1; i <= personsCount; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            persons.Add(new Person(tokens[0], int.Parse(tokens[1])));
        }

        persons.Where(p => p.Age > 30).OrderBy(p => p.ToString()).ToList().ForEach(p => Console.WriteLine(p));
    }
}
