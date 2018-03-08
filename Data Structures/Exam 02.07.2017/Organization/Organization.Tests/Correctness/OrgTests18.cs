using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class OrgTests18
{
    [Test]
    public void SearchWithNameSize_OnNonExistingRange_ShouldReturnEmptyCollection()
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
        IEnumerable<Person> Search() => org.SearchWithNameSize(1, 3);

        // Assert
        CollectionAssert.IsEmpty(Search());
    }
}
