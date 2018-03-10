using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class TestSkip
{
    [TestMethod]
    [Timeout(200)]
    public void Skip_OneTurn_NoInvaders()
    {
        Computer computer = new Computer(100);

        computer.Skip(1);

        Assert.AreEqual(100, computer.Energy);
        CollectionAssert.AreEqual(new List<Invader>(), computer.Invaders().ToList(), "Collections not equal");
    }

    [TestMethod]
    [Timeout(200)]
    public void Skip_OneTurn_OneInvader_ShouldDecreaseDistance()
    {
        Computer computer = new Computer(100);
        var invader = new Invader(10, 10);
        computer.AddInvader(invader);

        computer.Skip(1);
        
        Assert.AreEqual(100, computer.Energy, "Wrong energy");
        Assert.AreEqual(1, computer.Invaders().Count(), "Wrong count");
    }

    [TestMethod]
    [Timeout(200)]
    public void Skip_OneTurn_MultipleInvaders_ShouldDecreaseDistance()
    {
        Computer computer = new Computer(100);

        for (int i = 0; i < 100; i++)
        {
            var invader = new Invader(10, 10);
            computer.AddInvader(invader);
        }

        computer.Skip(1);

        Assert.AreEqual(100, computer.Energy, "Wrong energy");
        Assert.AreEqual(100, computer.Invaders().Count(), "Wrong count");
    }

    [TestMethod]
    [Timeout(200)]
    public void Skip_MultipleTurns_OneInvader_ShouldDoDamage()
    {
        Computer computer = new Computer(100);
        
        var invader = new Invader(10, 100);
        computer.AddInvader(invader);

        computer.Skip(10);
        computer.Skip(80);
        computer.Skip(10);

        Assert.AreEqual(90, computer.Energy, "Wrong energy");
        Assert.AreEqual(0, computer.Invaders().Count(), "Wrong count");
    }

    [TestMethod]
    [Timeout(200)]
    public void Skip_MultipleTurns_MultipleInvaders_ShouldDoDamage()
    {
        Computer computer = new Computer(100);

        for (int i = 0; i < 10; i++)
        {
            var invader = new Invader(10, 10 + i);
            computer.AddInvader(invader);
        }

        Assert.AreEqual(100, computer.Energy, "Wrong energy");
        Assert.AreEqual(10, computer.Invaders().Count(), "Wrong count");

        computer.Skip(5);

        Assert.AreEqual(100, computer.Energy, "Wrong energy");
        Assert.AreEqual(10, computer.Invaders().Count(), "Wrong count");

        computer.Skip(5);

        Assert.AreEqual(90, computer.Energy, "Wrong energy");
        Assert.AreEqual(9, computer.Invaders().Count(), "Wrong count");

        computer.Skip(5);

        Assert.AreEqual(40, computer.Energy, "Wrong energy");
        Assert.AreEqual(4, computer.Invaders().Count(), "Wrong count");

        computer.Skip(5);

        Assert.AreEqual(0, computer.Energy, "Wrong energy");
        Assert.AreEqual(0, computer.Invaders().Count(), "Wrong count");
    }
}
