using System;
using System.Collections.Generic;
using System.Text;

public class Axe : Weapon
{
    public Axe(WeaponRarity rarity, string name) 
        : base(rarity, name, 5, 10, 4)
    {
    }
}