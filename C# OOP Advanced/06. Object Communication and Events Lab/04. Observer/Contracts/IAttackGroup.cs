using System;
using System.Collections.Generic;
using System.Text;

public interface IAttackGroup
{
    void AddMember (IAttacker attacker);

    void GroupTarget(ITarget target);

    void GroupAttack();
}