using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestClass]
public class PerformanceDestroyInRadius
{
    [TestMethod]
    [Timeout(2000)]
    public void Performance_DestroyInRadius_TwoDistinctRadiuses()
    {
        Computer computer = new Computer(100);
        List<Invader> expected = new List<Invader>();

        for (int i = 1; i <= 20000; i++)
        {
            var invader = new Invader(1, i % 2 + 1);
            computer.AddInvader(invader);
            if (i % 2 + 1 == 2)
            {
                expected.Add(invader);
            }
        }

        var sw = new Stopwatch();
        sw.Start();

        computer.DestroyTargetsInRadius(1);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 200, "Timeout");

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expected, actual, "Collections not equal");

        Assert.AreEqual(100, computer.Energy, "Wrong energy");
    }

    [TestMethod]
    [Timeout(2000)]
    public void Performance_DestroyInRadius()
    {
        Computer computer = new Computer(100);
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

        computer.DestroyTargetsInRadius(10000);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 100, "Timeout");

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expected, actual, "Collections not equal");

        Assert.AreEqual(100, computer.Energy, "Wrong energy");
    }

    [TestMethod]
    [Timeout(2000)]
    public void Performance_DestroyInRadius_Random()
    {
        Random rnd = new Random();
        Computer computer = new Computer(100);
        List<Invader> expectedInvadersFirstRound = new List<Invader>();
        List<Invader> expectedInvadersSecondRound = new List<Invader>();

        for (int i = 1; i <= 30000; i++)
        {
            var distance = rnd.Next(1000);
            var damage = rnd.Next(1000);
            var invader = new Invader(damage, distance);
            computer.AddInvader(invader);

            if (distance > 250)
            {
                expectedInvadersFirstRound.Add(invader);
            }

            if (distance > 500)
            {
                expectedInvadersSecondRound.Add(invader);
            }
        }

        var sw = new Stopwatch();
        sw.Start();

        computer.DestroyTargetsInRadius(100);
        computer.DestroyTargetsInRadius(200);
        computer.DestroyTargetsInRadius(250);

        var exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 150, "Timeout");

        var actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expectedInvadersFirstRound, actual, "Collections not equal");

        sw.Start();

        computer.DestroyTargetsInRadius(300);
        computer.DestroyTargetsInRadius(400);
        computer.DestroyTargetsInRadius(500);

        exercutionTime = sw.ElapsedMilliseconds;
        Assert.IsTrue(exercutionTime <= 100, "Timeout");

        actual = computer.Invaders().ToList();
        CollectionAssert.AreEqual(expectedInvadersSecondRound, actual, "Collections not equal");
    }
}
