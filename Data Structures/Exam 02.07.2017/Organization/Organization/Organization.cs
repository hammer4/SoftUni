using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Organization : IOrganization
{
    private List<Person> byInsertion = new List<Person>();
    private Dictionary<string, LinkedList<Person>> byName = new Dictionary<string, LinkedList<Person>>();
    private OrderedDictionary<int, LinkedList<Person>> byNameLength = new OrderedDictionary<int, LinkedList<Person>>();
    private HashSet<Person> personsHashSet = new HashSet<Person>();

    public IEnumerator<Person> GetEnumerator()
    {
        foreach(var item in this.byInsertion)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count { get { return this.byInsertion.Count; } }
    public bool Contains(Person person)
    {
        return this.personsHashSet.Contains(person);
    }

    public bool ContainsByName(string name)
    {
        return this.byName.ContainsKey(name);
    }

    public void Add(Person person)
    {
        this.byInsertion.Add(person);
        if (!this.byName.ContainsKey(person.Name))
        {
            this.byName[person.Name] = new LinkedList<Person>();
        }
        this.byName[person.Name].AddLast(person);

        if (!this.byNameLength.ContainsKey(person.Name.Length))
        {
            this.byNameLength[person.Name.Length] = new LinkedList<Person>();
        }
        this.byNameLength[person.Name.Length].AddLast(person);
        this.personsHashSet.Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if(index < 0 || index >= this.byInsertion.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return this.byInsertion[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        if (this.byName.ContainsKey(name))
        {
            return this.byName[name];
        }

        return new List<Person>();
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        for(int i=0; i<Math.Min(count, this.byInsertion.Count); i++)
        {
            yield return this.byInsertion[i];
        }
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        foreach(var item in this.byNameLength.Range(minLength, true, maxLength, true))
        {
            foreach(var subItem in item.Value)
            {
                yield return subItem;
            }
        }
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        if (!this.byNameLength.ContainsKey(length))
        {
            throw new ArgumentException();
        }

        return this.byNameLength[length];
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return this.byInsertion;
    }
}