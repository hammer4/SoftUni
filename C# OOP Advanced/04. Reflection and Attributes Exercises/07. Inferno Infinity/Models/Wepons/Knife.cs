using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    public Knife(WeaponRarity rarity, string name) 
        : base(rarity, name, 3, 4, 2)
    {
    }
}