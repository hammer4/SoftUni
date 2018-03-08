using NUnit.Framework;

[TestFixture]
class OrgTests1
{
    [Test]
    public void Add_SingleElement_ShouldAddElement()
    {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.Add(p);

        // Assert
        foreach (Person person in org)
        {
            if (person.Name == p.Name && person.Salary == p.Salary)
            {
                Assert.Pass();
            }
        }
    }
}
