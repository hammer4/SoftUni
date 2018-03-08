using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
class PerfTests05
{
    [Test]
    public void ContainsByName_On100000Elements_ShouldWorkFast()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
        List<string> names = new List<string>(100_000);

        for (int i = 0; i < count; i++)
        {
            Person p = new Person(i.ToString(), i);
            org.Add(p);
            names.Add(p.Name);
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        bool Result(int index)
        {
            return org.ContainsByName(names[index]);
        }

        // Assert
        for (int i = 0; i < count; i++)
        {
            Assert.True(Result(i));
        }

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 200);
    }
}
