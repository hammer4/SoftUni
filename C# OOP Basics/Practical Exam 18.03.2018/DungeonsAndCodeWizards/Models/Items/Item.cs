using System;
using System.Collections.Generic;
using System.Text;

public abstract class Item
{
    private int weight;

    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public int Weight
    {
        get { return weight; }
        private set { weight = value; }
    }

    public virtual void AffectCharacter(Character character)
    {
        character.CheckAlive();
    }
}