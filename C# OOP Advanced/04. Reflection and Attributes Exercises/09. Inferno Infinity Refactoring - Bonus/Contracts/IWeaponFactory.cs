using System;
using System.Collections.Generic;
using System.Text;

public interface IWeaponFactory
{
    IWeapon CreateWeapon(string weaponRarity, string weaponType, string name);
}