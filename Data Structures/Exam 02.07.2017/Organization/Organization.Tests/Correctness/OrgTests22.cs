using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class OrgTests22
{
    [Test]
    public void FirstByInsertOrder_WithParameters_ShouldReturnCorrectElements()
    {
        // Arrange
        IOrganization org = new Organization();
        List<Person> people = new List<Person>
        {
            new Person("Ivan", 350),
            new Person("Pesho", 1200),
            new Person("Mitko", 20)
        };

        foreach (Person person in people)
        {
            org.Add(person);
        }

        // Act
        IEnumerable<Person> Result() => org.FirstByInsertOrder(3);

        // Assert
        CollectionAssert.AreEqual(people, Result());
    }
}