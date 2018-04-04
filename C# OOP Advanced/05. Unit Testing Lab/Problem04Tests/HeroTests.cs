using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class HeroTests
{
    private const int fakeAxeAttackPoints = 10;
    private const int fakeTargetHealth = 20;
    private const int fakeTargetExperience = 50;

    private class FakeTarget : ITarget
    {
        public FakeTarget()
        {
            this.Health = fakeTargetHealth;
        }

        public int Health { get; private set; }

        public int GiveExperience()
        {
            return fakeTargetExperience;
        }

        public bool IsDead()
        {
            return this.Health <= 0;
        }

        public void TakeAttack(int attackPoints)
        {
            this.Health -= attackPoints;
        }
    }

    private class FakeAxe : IWeapon
    {
        public FakeAxe()
        {
            this.AttackPoints = fakeAxeAttackPoints;
        }

        public int AttackPoints { get; private set; }

        public void Attack(ITarget target)
        {
            target.TakeAttack(AttackPoints);
        }
    }

    [Test]
    public void HeroShouldGainExperienceWhenTargetDies()
    {
        Hero hero = new Hero("Grigor", new FakeAxe());
        ITarget fakeTarget = new FakeTarget();

        hero.Attack(fakeTarget);

        Assert.That(hero.Experience, Is.EqualTo(0));

        hero.Attack(fakeTarget);

        Assert.That(hero.Experience, Is.EqualTo(fakeTargetExperience));
    }

    [Test]
    public void HeroShouldGainExperienceWhenTargetDiesMocking()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(20));

    }
}

