using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
class PerfTests01
{
    [Test]
    public void Add_50000Elements_ShouldWork()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
        
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < count; i++)
        {
            org.Add(new Person(i.ToString(), i));
        }

        stopwatch.Stop();
        
        Assert.Less(stopwatch.ElapsedMilliseconds, 350, "The code runs too slow");
    }
}
