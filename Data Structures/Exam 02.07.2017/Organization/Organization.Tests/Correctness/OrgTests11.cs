using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class OrgTests11
{
    [Test]
    public void GetByName_OnMultipleEqualNames_ShouldReturnCorrectObjects()
    {
        // Arrange
        IOrganization org = new Organization();
        List<Person> people = new List<Person>
        {
            new Person("pesho", 350),
            new Person("Pesho", 1200),
            new Person("Pesho", 20),
            new Person("peshO", 0),
            new Person("Stamat", 1500),
            new Person("Alex", 850),
            new Person("peshO", 3000)
        };

        // Act
        foreach (Person person in people)
        {
            org.Add(person);
        }

        // Assert
        CollectionAssert.AreEquivalent(people.Where(x => x.Name == "Pesho"), org.GetByName("Pesho"));
    }
}
