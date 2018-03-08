using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
class PerfTests08
{
    [Test]
    public void PeopleByInsertOrder_On100000Elements_ShouldWorkFast()
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
        // Act & Assert
        CollectionAssert.AreEqual(people, org.PeopleByInsertOrder());
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 150);
    }
}
