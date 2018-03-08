using NUnit.Framework;

class OrgTests5
{
    [Test]
    public void Contains_NonExistingElement_ShouldReturnTrue()
    {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        bool actual = org.Contains(p);

        // Assert
        Assert.False(actual);
    }
}