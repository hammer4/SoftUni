using NUnit.Framework;

[TestFixture]
class OrgTests2
{
    [Test]
    public void Add_SingleElement_ShouldIncreaseCount()
    {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.Add(p);

        // Assert
        Assert.AreEqual(1, org.Count);
    }
}

