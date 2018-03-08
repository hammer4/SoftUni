using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class PerfTests09
{
    [Test]
    public void GetWithNameSize_On100000ElementsWithRandomLength_ShouldWorkFast()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
        int expected = 0;

        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int len = random.Next(1, 100);
            if (len == 35) expected++;
            org.Add(new Person(new string('a', len), 25));
        }
        
        Stopwatch sw = Stopwatch.StartNew();
        // Act
        int GetWithNameSize() => org.GetWithNameSize(35).Count();

        // Assert
        Assert.AreEqual(expected, GetWithNameSize());
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 25);
    }
}
