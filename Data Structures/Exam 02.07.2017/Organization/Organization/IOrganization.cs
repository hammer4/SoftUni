using System.Collections.Generic;

public interface IOrganization : IEnumerable<Person>
{
    int Count { get; }
    bool Contains(Person person);
    bool ContainsByName(string name);
    void Add(Person person);
    Person GetAtIndex(int index);

    IEnumerable<Person> GetByName(string name);
    IEnumerable<Person> FirstByInsertOrder(int count = 1);
    IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength);
    IEnumerable<Person> GetWithNameSize(int length);
    IEnumerable<Person> PeopleByInsertOrder();
}