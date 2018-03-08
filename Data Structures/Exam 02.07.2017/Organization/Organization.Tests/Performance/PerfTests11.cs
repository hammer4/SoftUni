using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class PerfTests11
{
    [Test]
    public void SearchWithNameSize_OnLargeRange_ShouldWorkFast()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
        int expected = 0;
        
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int len = random.Next(1, 100);
            if (len >= 35 && len <= 635) expected++;

            org.Add(new Person(new string('a', len), 25));
        }

        Stopwatch sw = Stopwatch.StartNew();
        // Act
        IEnumerable<Person> GetWithNameSize() => org.SearchWithNameSize(35, 635);

        // Assert
        Assert.AreEqual(expected, GetWithNameSize().Count());

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 230);
    }
}
