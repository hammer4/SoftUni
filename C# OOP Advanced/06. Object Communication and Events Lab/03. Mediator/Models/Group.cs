using System;
using System.Collections.Generic;
using System.Text;

public class Group : IAttackGroup
{
    private List<IAttacker> attackers;

    public Group()
    {
        this.attackers = new List<IAttacker>();
    }

    public void AddMember(IAttacker attacker)
    {
        this.attackers.Add(attacker);
    }

    public void GroupAttack()
    {
        foreach(var attacker in attackers)
        {
            attacker.Attack();
        }
    }

    public void GroupTarget(ITarget target)
    {
        foreach(var attacker in attackers)
        {
            attacker.SetTarget(target);
        }
    }

    public void GroupTargetAndAttack(ITarget target)
    {
        this.GroupTarget(target);
        this.GroupAttack();
    }
}