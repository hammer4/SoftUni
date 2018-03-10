using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestClass]
public class PerformanceAdd
{
    [TestMethod]
    [Timeout(2000)]
    public void Performance_Add_ShouldBeAddedInCorrectOrder()
    {
        Computer computer = new Computer(100);
        List<Invader> expected = new List<Invader>();

        var sw = new Stopwatch();
        sw.Start();

        for (int i = 1; i <= 20000; i++)
        {
            var invader = new Invader(i, i);
            computer.AddInvader(invader);
            expected.Add(invader);
        }

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 100, "Timeout");

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expected, actual, "Collections not equal");
    }
}
