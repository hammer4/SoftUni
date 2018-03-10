using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class TestAdd
{
    [TestMethod]
    [Timeout(200)]
    public void Add_One_ShouldBeAdded()
    {
        Computer computer = new Computer(100);
        List<Invader> invaders = new List<Invader>();

        var invader = new Invader(10, 10);

        computer.AddInvader(invader);
        invaders.Add(invader);

        var invaderCount = computer.Invaders().Count();

        Assert.AreEqual(invaders.Count, invaderCount, "Wrong count");
    }

    [TestMethod]
    [Timeout(200)]
    public void Add_Many_ShouldBeAddedInCorrectOrder()
    {
        Computer computer = new Computer(100);
        List<Invader> invaders = new List<Invader>();

        for (int i = 1; i <= 100; i++)
        {
            var invader = new Invader(i, i);
            computer.AddInvader(invader);
            invaders.Add(invader);
        }

        var invaderCount = computer.Invaders().Count();

        Assert.AreEqual(invaders.Count, invaderCount, "Wrong count");
    }
}
