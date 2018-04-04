using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class DummyTests
{
    [Test]
    public void DummyLoosesHealthIfAttacked()
    {
        Dummy dummy = new Dummy(10, 15);
        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(5));
    }

    [Test]
    public void AttackDeadDummyShouldThrow()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.That(() => dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        Hero hero = new Hero("Grigor");
        Dummy dummy = new Dummy(10, 50);

        hero.Attack(dummy);

        Assert.That(hero.Experience, Is.EqualTo(50));
    }

    [Test]
    public void AliveDummyCantGiveExperience()
    {
        Hero hero = new Hero("Grigor");
        Dummy dummy = new Dummy(20, 50);

        hero.Attack(dummy);

        Assert.That(hero.Experience, Is.EqualTo(0));
    }
}