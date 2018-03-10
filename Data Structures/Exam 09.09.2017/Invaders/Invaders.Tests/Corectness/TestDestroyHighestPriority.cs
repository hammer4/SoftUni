using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class TestDestroyHighestPriority
{
    [TestMethod]
    [Timeout(200)]
    public void DestroyHighestPriority_NoTargets()
    {
        Computer computer = new Computer(100);

        computer.DestroyHighestPriorityTargets(100);

        CollectionAssert.AreEqual(new List<Invader>(), computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void DestroyHighestPriority_AllTargets()
    {
        Computer computer = new Computer(100);

        for (int i = 1; i <= 100; i++)
        {
            computer.AddInvader(new Invader(i, i));
        }

        computer.DestroyHighestPriorityTargets(100);

        CollectionAssert.AreEqual(new List<Invader>(), computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void DestroyHighestPriority_MultipleTargets()
    {
        Random random = new Random();
        Computer computer = new Computer(100);
        List<Invader> expected = new List<Invader>();

        for (int i = 1; i <= 100; i++)
        {
            var invader = new Invader(random.Next(50), random.Next(50));
            computer.AddInvader(invader);
            expected.Add(invader);
        }

        computer.DestroyHighestPriorityTargets(50);
        
        var toRemove = expected.OrderBy(x => x.Distance).ThenBy(x => -x.Damage).Take(50).ToList();
        expected.RemoveAll(x => toRemove.Contains(x));

        CollectionAssert.AreEqual(expected, computer.Invaders().ToList(), "Collections not equal");
    }
}
