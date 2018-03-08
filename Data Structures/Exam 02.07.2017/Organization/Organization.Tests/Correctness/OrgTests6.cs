using NUnit.Framework;

[TestFixture]
class OrgTests6
{
    [Test]
    public void ContainsByName_ExistingName_ShouldReturnTrue()
    {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.Add(p);
        bool actual = org.ContainsByName(p.Name);

        // Assert
        Assert.True(actual);
    }
}
