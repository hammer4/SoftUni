using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class OrgTests17
{
    [Test]
    public void SearchWithNameSize_OnExistingRange_ShouldReturnElementsInRange()
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
        IEnumerable<Person> Search() => org.SearchWithNameSize(4, 5);

        // Assert
        CollectionAssert.AreEquivalent(people.Where(x => x.Name.Length == 4 || x.Name.Length == 5), Search());
    }
}