using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class OrgTests24
{
    [Test]
    public void FirstInInsertOrder_OnPartialRange_ShouldReturnPartialRange()
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

        // Act
        IEnumerable<Person> Result() => org.FirstByInsertOrder(300);

        // Assert
        CollectionAssert.AreEqual(people, Result());
    }
}
