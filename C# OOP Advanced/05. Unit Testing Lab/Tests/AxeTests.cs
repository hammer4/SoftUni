using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class AxeTests
{
    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void AttackWithBrokenAxeShouldThrow()
    {
        Axe axe = new Axe(5, 0);
        Dummy dummy = new Dummy(10, 10);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}