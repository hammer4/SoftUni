using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByemailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsBytownAndAge =
        new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();


    public bool AddPerson(string email, string name, int age, string town)
    {
        if(this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        this.personsByEmail.Add(email, person);

        string emailDomain = this.ExtractEmailDomain(email);
        this.personsByemailDomain.AppendValueToKey(emailDomain, person);

        string nameAndTown = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        this.personsByAge.AppendValueToKey(age, person);

        this.personsBytownAndAge.EnsureKeyExists(town);
        this.personsBytownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];
        return domain;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExists = this.personsByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        if(person == null)
        {
            return false;
        }

        var personDeleted = this.personsByEmail.Remove(email);

        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByemailDomain[emailDomain].Remove(person);

        string nameAndTown = CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        this.personsByAge[person.Age].Remove(person);

        this.personsBytownAndAge[person.Town][person.Age].Remove(person);

        return personDeleted;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personsByemailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string nameAndTown = this.CombineNameAndTown(name, town);
        return this.personsByNameAndTown.GetValuesForKey(nameAndTown);
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string separator = "|!|";
        return name + separator + town;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = this.personsByAge.Range(startAge, true, endAge, true);

        foreach(var personsByAge in personsInRange)
        {
            foreach(var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsBytownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var personsInRange = this.personsBytownAndAge[town].Range(startAge, true, endAge, true);

        foreach(var personsByAge in personsInRange)
        {
            foreach(var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }
}
