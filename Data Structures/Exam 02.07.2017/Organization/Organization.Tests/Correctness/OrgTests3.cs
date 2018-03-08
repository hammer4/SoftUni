using NUnit.Framework;

[TestFixture]
class OrgTests3
{
    [Test]
    public void Add_SingleElement_ShouldBeReturnedAsFirstElementByIndex()
    {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.Add(p);

        // Assert
        Assert.AreEqual(p, org.GetAtIndex(0));
    }
}
