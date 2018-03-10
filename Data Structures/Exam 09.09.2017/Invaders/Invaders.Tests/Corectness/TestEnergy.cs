using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TestEnergy
{
    [TestMethod]
    [Timeout(200)]
    [ExpectedException(typeof(ArgumentException))]
    public void Energy_InitializeWithNegativeEnergy_ShouldThrow()
    {
        Computer computer = new Computer(-100);
    }

    [TestMethod]
    [Timeout(200)]
    public void Energy_DamageOnce_ShouldHaveCorrectEnergy()
    {
        Computer computer = new Computer(100);

        computer.AddInvader(new Invader(10, 1));
        computer.Skip(1);

        Assert.AreEqual(90, computer.Energy, "Wrong energy");
    }

    [TestMethod]
    [Timeout(200)]
    public void Energy_DamageMultipleTimes_ShouldHaveCorrectEnergy()
    {
        Computer computer = new Computer(100);

        for (int i = 0; i < 50; i++)
        {
            computer.AddInvader(new Invader(1, 1));
        }

        computer.Skip(1);

        Assert.AreEqual(50, computer.Energy, "Wrong energy");
    }

    [TestMethod]
    [Timeout(200)]
    public void Energy_DamageUntilNegative_ShouldHaveZeroEnergy()
    {
        Computer computer = new Computer(100);

        for (int i = 0; i < 200; i++)
        {
            computer.AddInvader(new Invader(1, 1));
        }

        computer.Skip(1);

        Assert.AreEqual(0, computer.Energy, "Wrong energy");
    }
}
