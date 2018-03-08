using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
class PerfTests02
{
    [Test]
    public void Contains_Existing100000Elements_ShouldWorkCorrectly()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
        LinkedList<Person> people = new LinkedList<Person>();

        for (int i = 0; i < count; i++)
        {
            people.AddLast(new Person(i.ToString(), i));
            org.Add(people.Last.Value);
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        LinkedListNode<Person> node = people.First;
        while (node != null)
        {
            Assert.True(org.Contains(node.Value));
            node = node.Next;
        }

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 200);
    }
}
