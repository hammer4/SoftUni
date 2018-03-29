using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public int CompareTo(Person other)
    {
        if(this.Name.CompareTo(other.Name) != 0)
        {
            return this.Name.CompareTo(other.Name);
        }

        return this.Age.CompareTo(other.Age);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() ^ this.Age.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        var other = obj as Person;

        if(other == null)
        {
            return false;
        }

        return this.Age == other.Age && this.Name == other.Name;
    }
}