using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Family
{
    private List<Person> persons;

    public Family()
    {
        this.persons = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.persons.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.persons.OrderByDescending(m => m.Age).ToList().First();
    }
}
