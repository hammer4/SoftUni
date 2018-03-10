using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class PerformanceDestroyHighestPriority
{
    [TestMethod]
    [Timeout(2000)]
    public void Performance_DestroyHighestPriority()
    {
        Computer computer = new Computer(100);
        List<Invader> expected = new List<Invader>();

        for (int i = 1; i <= 20000; i++)
        {
            var invader = new Invader(1, i);
            computer.AddInvader(invader);
            expected.Add(invader);
        }

        expected = expected.OrderBy(x => x.Distance).ThenBy(x => -x.Damage).Skip(10000).ToList();

        var sw = new Stopwatch();
        sw.Start();

        computer.DestroyHighestPriorityTargets(10000);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 100, "Timeout");

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expected, actual, "Collections not equal");
    }

    [TestMethod]
    [Timeout(2000)]
    public void Performance_DestroyHighestPriority_Random()
    {
        Random rnd = new Random();
        Computer computer = new Computer(100);
        List<Invader> expected = new List<Invader>();

        for (int i = 1; i <= 10000; i++)
        {
            var distance = rnd.Next(1000);
            var damage = rnd.Next(1000);
            var invader = new Invader(damage, distance);
            computer.AddInvader(invader);
            expected.Add(invader);
        }

        var sw = new Stopwatch();
        sw.Start();

        computer.DestroyHighestPriorityTargets(5000);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 100, "Timeout");

        var toRemove = expected.OrderBy(x => x.Distance).ThenBy(x => -x.Damage).Take(5000).ToList();
        expected.RemoveAll(x => toRemove.Contains(x));

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expected, actual, "Collections not equal");
    }
}