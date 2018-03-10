using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class TestDestroyInRadius
{
    [TestMethod]
    [Timeout(200)]
    public void DestroyInRadius_NoTargets()
    {
        Computer computer = new Computer(100);

        computer.DestroyTargetsInRadius(100);

        CollectionAssert.AreEqual(new List<Invader>(), computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void DestroyInRadius_OneTarget()
    {
        Computer computer = new Computer(100);

        computer.AddInvader(new Invader(1, 1));

        computer.DestroyTargetsInRadius(100);

        CollectionAssert.AreEqual(new List<Invader>(), computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void DestroyInRadius_AllTargets()
    {
        Computer computer = new Computer(100);

        for (int i = 0; i < 100; i++)
        {
            computer.AddInvader(new Invader(i, i));
        }

        computer.DestroyTargetsInRadius(100);

        CollectionAssert.AreEqual(new List<Invader>(), computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void DestroyInRadius_TargetOutOfReach_ShouldNotDestroy()
    {
        Computer computer = new Computer(100);
        List<Invader> actual = new List<Invader>();
        Invader invader = new Invader(10, 10);

        computer.AddInvader(invader);
        actual.Add(invader);

        computer.DestroyTargetsInRadius(9);

        CollectionAssert.AreEqual(actual, computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void DestroyInRadius_MultipleTargets_ShouldDestroyInRadius()
    {
        Computer computer = new Computer(100);
        List<Invader> actual = new List<Invader>();

        for (int i = 1; i <= 100; i++)
        {
            Invader invader = new Invader(i, i);
            computer.AddInvader(invader);
            if (i > 50)
            {
                actual.Add(invader);
            }
        }

        computer.DestroyTargetsInRadius(50);

        CollectionAssert.AreEqual(actual, computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void DestroyInRadius_MultipleRandomTargets_ShouldDestroyInRadius()
    {
        Computer computer = new Computer(100);
        List<Invader> actual = new List<Invader>();
        Random rnd = new Random();

        for (int i = 1; i <= 1000; i++)
        {
            int distance = rnd.Next(100);
            Invader invader = new Invader(0, distance);
            computer.AddInvader(invader);
            if (distance > 50)
            {
                actual.Add(invader);
            }
        }

        computer.DestroyTargetsInRadius(50);

        CollectionAssert.AreEqual(actual, computer.Invaders().ToList(), "Collections not equal");
    }
}
