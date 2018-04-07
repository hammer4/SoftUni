using System;
using System.Collections.Generic;
using System.Text;

public class GroupAttackCommand : ICommand
{
    private IAttackGroup attackGroup;

    public GroupAttackCommand(IAttackGroup attackGroup)
    {
        this.attackGroup = attackGroup;
    }

    public void Execute()
    {
        this.attackGroup.GroupAttack();
    }
}