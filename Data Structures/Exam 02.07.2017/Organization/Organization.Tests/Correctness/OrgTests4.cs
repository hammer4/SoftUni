using NUnit.Framework;

[TestFixture]
class OrgTests4
{
    [Test]
    public void Contains_ExistingElement_ShouldReturnTrue()
    {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.Add(p);
        bool actual = org.Contains(p);

        // Assert
        Assert.True(actual);
    }
}