using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class OrgTests16
{
    [Test]
    public void GetWithNameSize_WithInvalidLength_ShouldThrow()
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
        IEnumerable<Person> GetWithNameSize() => org.GetWithNameSize(3);

        // Assert
        Assert.That(GetWithNameSize, Throws.ArgumentException);
    }
}