using System;
using System.Collections.Generic;
using System.Text;

public class ItemFactory
{
    public static Item CreateItem(string type)
    {
        switch (type)
        {
            case nameof(ArmorRepairKit):
                return new ArmorRepairKit();
            case nameof(HealthPotion):
                return new HealthPotion();
            case nameof(PoisonPotion):
                return new PoisonPotion();
            default:
                throw new ArgumentException($"Invalid item type \"{type}\"!");
        }
    }
}