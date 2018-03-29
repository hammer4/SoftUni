using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> byName = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> byAge = new SortedSet<Person>(new AgeComparator());

        int count = int.Parse(Console.ReadLine());

        for(int i=0; i<count; i++)
        {
            string[] input = Console.ReadLine().Split();

            Person person = new Person(input[0], int.Parse(input[1]));
            byName.Add(person);
            byAge.Add(person);
        }

        foreach(var person in byName)
        {
            Console.WriteLine(person);
        }

        foreach(var person in byAge)
        {
            Console.WriteLine(person);
        }
    }
}