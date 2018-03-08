using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
public class PerfTests04
{
    [Test]
    public void Count_OnManyElements_ShouldWork()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
       
        // Act & Assert
        for (int i = 0; i < count; i++)
        {
            Assert.AreEqual(i, org.Count);
            org.Add(new Person(i.ToString(), i));
        }
    }
}