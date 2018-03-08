using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class OrgTests13
{
    [Test]
    public void GetAtIndex_WithManyElements_ShouldReturnCorrectly()
    {
        // Arrange
        IOrganization org = new Organization();
        List<Person> people = new List<Person>
        {
            new Person("Ivan", 350),
            new Person("Pesho", 1200),
            new Person("Mitko", 20),
            new Person("Maria", 0),
            new Person("Stamat", 1500),
            new Person("Alex", 850),
            new Person("Rosi", 3000)
        };

        foreach (Person person in people)
        {
            org.Add(person);
        }
        
        // Act & Assert
        Assert.AreEqual(people[1], org.GetAtIndex(1));
        Assert.AreEqual(people[3], org.GetAtIndex(3));
        Assert.AreEqual(people[5], org.GetAtIndex(5));
    }
}
