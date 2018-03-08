using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class PerfTests07
{
    [Test]
    public void GetByName_OnTwoUniqueNamesWith100000Elements_ShouldWorkFast()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;

        for (int i = 0; i < count; i++)
        {
            org.Add(new Person("0", i));
        }
        org.Add(new Person("1", 1));

        // Act & Assert
        Stopwatch sw = Stopwatch.StartNew();
        Assert.AreEqual(1, org.GetByName("1").Count());
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 20);
    }
}
