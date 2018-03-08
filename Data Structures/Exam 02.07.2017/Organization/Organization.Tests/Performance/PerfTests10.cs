using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class PerfTests10
{
    [Test]
    public void FirstByInsertOrder_On100000Elements_ShouldWorkFast()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
        List<Person> people = new List<Person>();

        for (int i = 0; i < count; i++)
        {
            people.Add(new Person(i.ToString(), i));
            org.Add(people[i]);
        }

        Stopwatch sw = Stopwatch.StartNew();
        // Act
        IEnumerable<Person> Result() => org.FirstByInsertOrder(50_000);

        // Assert
        CollectionAssert.AreEqual(people.Take(50_000), Result());
        sw.Stop();

        Assert.Less(sw.ElapsedMilliseconds, 40);
    }
}
