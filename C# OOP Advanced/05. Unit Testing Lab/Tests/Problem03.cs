using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class Problem03
{
    private const int attackPoints = 2;
    private const int durabilityPoints = 2;
    private const int dummyHealth = 6;
    private const int dummyExpirience = 5;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(attackPoints, durabilityPoints);
        this.dummy = new Dummy(dummyHealth, dummyExpirience);
    }

    [TearDown]
    public void CleanUp()
    {
        axe = null;
        dummy = null;
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);
        int expectedDurability = durabilityPoints - 1;

        Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurability), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void AttackWithBrokenAxeShouldThrow()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."), "Unappropriate message");
    }

    [Test]
    public void DummyLoosesHealthIfAttacked()
    {
        int damageTaken = 5;
        int expectedHealth = dummy.Health - damageTaken;

        dummy.TakeAttack(damageTaken);

        Assert.That(dummy.Health, Is.EqualTo(expectedHealth), "Inproper amount of health taken from Dummy");
    }

    [Test]
    public void AttackDeadDummyShouldThrow()
    {
        int damageTaken = 6;
        dummy.TakeAttack(damageTaken);

        Assert.That(() => dummy.TakeAttack(damageTaken), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), "Inappropriate message");
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        dummy.TakeAttack(dummy.Health);
        Assert.That(dummy.GiveExperience(), Is.EqualTo(dummyExpirience), "Dead dummy doesn't give correct amount of expirence");
    }

    [Test]
    public void AliveDummyCantGiveExperience()
    {
        int dummyHealth = 20;

        dummy = new Dummy(dummyHealth, dummyExpirience);

        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Alive dummy changes experience");
    }
}