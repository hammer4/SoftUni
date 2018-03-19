using System;
using System.Collections.Generic;
using System.Text;

public class HealthPotion : Item
{
    public HealthPotion()
        : base(5)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);

        character.IncreaseHealth(20);
    }
}