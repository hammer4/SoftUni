using System;
using System.Collections.Generic;
using System.Text;

public interface IRepository
{
    void AddWeapon(IWeapon weapon);

    void AddGem(string weaponName, int index, IGem gem);

    void RemoveGem(string weaponName, int index);

    string PrintWeapon(string name);
}