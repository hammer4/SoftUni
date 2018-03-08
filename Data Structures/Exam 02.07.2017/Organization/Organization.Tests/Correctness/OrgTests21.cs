using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class OrgTests21
{
    [Test]
    public void FirstByInsertOrder_WithoutParameters_ShouldReturnFirstElement()
    {
        // Arrange
        IOrganization org = new Organization();
        List<Person> people = new List<Person>
        {
            new Person("Ivan", 350),
            new Person("Pesho", 1200),
            new Person("Mitko", 20),
        };

        foreach (Person person in people)
        {
            org.Add(person);
        }

        // Act
        IEnumerable<Person> Result() => org.FirstByInsertOrder();

        // Assert
        CollectionAssert.AreEqual(people.Take(1), Result());
    }
}