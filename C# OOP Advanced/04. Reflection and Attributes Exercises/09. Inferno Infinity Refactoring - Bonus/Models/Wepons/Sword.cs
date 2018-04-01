using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    public Sword(WeaponRarity rarity, string name) 
        : base(rarity, name, 4, 6, 3)
    {
    }
}