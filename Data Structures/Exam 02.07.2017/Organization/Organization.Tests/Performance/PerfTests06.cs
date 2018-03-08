using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class PerfTests06
{
    [Test]
    public void GetByName_OnManyRepeatingNames_ShouldWorkFast()
    {
        // Arrange
        IOrganization org = new Organization();
        const int count = 100_000;
        int filler = 0;

        for (int i = 0; i < count; i++)
        {
            if (filler == 100)
            {
                filler = 0;
            }

            org.Add(new Person(filler.ToString(), i));

            filler++;
        }

        Stopwatch sw = Stopwatch.StartNew();
        // Act & Assert
        Assert.AreEqual(1000, org.GetByName("0").Count());

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 30);
    }
}