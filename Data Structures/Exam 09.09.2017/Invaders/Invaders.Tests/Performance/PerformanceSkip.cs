using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class PerformanceSkip
{
    [TestMethod]
    [Timeout(2000)]
    public void Performance_Skip_Contact()
    {
        Computer computer = new Computer(20000);
        List<Invader> expected = new List<Invader>();

        for (int i = 1; i <= 20000; i++)
        {
            var invader = new Invader(1, i);
            computer.AddInvader(invader);

            if (i > 10000)
            {
                expected.Add(invader);
            }
        }

        var sw = new Stopwatch();
        sw.Start();

        computer.Skip(10000);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 150, "Timeout");

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expected, actual, "Collections not equal");

        Assert.AreEqual(10000, computer.Energy, "Wrong energy");
    }

    [TestMethod]
    [Timeout(2000)]
    public void Performance_Skip_AllContact()
    {
        Computer computer = new Computer(20000);
        List<Invader> expected = new List<Invader>();

        for (int i = 1; i <= 19999; i++)
        {
            var invader = new Invader(1, 20000);
            computer.AddInvader(invader);
        }

        var sw = new Stopwatch();
        sw.Start();

        computer.Skip(20000);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 150, "Timeout");

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expected, actual, "Collections not equal");

        Assert.AreEqual(1, computer.Energy, "Wrong energy");
    }

    [TestMethod]
    [Timeout(2000)]
    public void Performance_Skip_Random()
    {
        int initialEnergy = int.MaxValue;

        Random rnd = new Random();
        Computer computer = new Computer(initialEnergy);
        List<Invader> expectedInvaders = new List<Invader>();
        int expectedDamage = 0;

        for (int i = 1; i <= 20000; i++)
        {
            var distance = rnd.Next(1000);
            var damage = rnd.Next(1000);
            var invader = new Invader(damage, distance);
            computer.AddInvader(invader);

            if (distance > 500)
            {
                expectedInvaders.Add(invader);
            }
            else
            {
                expectedDamage += damage;
            }
        }

        var sw = new Stopwatch();
        sw.Start();

        computer.Skip(500);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 100, "Timeout");

        var actual = computer.Invaders().ToList();

        CollectionAssert.AreEqual(expectedInvaders, actual, "Collections not equal");
        Assert.AreEqual(initialEnergy - expectedDamage, computer.Energy, "Wrong energy");
    }

    [TestMethod]
    [Timeout(2000)]
    public void Performance_Complex_ShouldHaveCorrectEnergy()
    {
        Computer computer = new Computer(20000);
        List<Invader> expected = new List<Invader>();

        for (int i = 1; i <= 20000; i++)
        {
            var invader = new Invader(1, i);
            computer.AddInvader(invader);
            if (i > 19000)
            {
                expected.Add(invader);
            }
        }

        var sw = new Stopwatch();
        sw.Start();

        computer.DestroyHighestPriorityTargets(1000);
        computer.Skip(1000);
        computer.DestroyTargetsInRadius(1000);
        computer.Skip(1000);
        computer.Skip(1000);
        computer.DestroyTargetsInRadius(5000);
        computer.DestroyHighestPriorityTargets(11000);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 300, "Timeout");

        var actual = computer.Invaders().ToList();

        CollectionAssert.AreEqual(expected, actual, "Collections not equal");
        Assert.AreEqual(19000, computer.Energy, "Wrong energy");
    }
}
