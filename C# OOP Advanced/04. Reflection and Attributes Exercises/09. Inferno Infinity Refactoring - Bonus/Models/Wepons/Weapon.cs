using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Weapon : IWeapon, IRareWeapon
{
    IGem[] slots;

    protected Weapon(WeaponRarity rarity, string name, int baseMinDamage, int baseMaxDamage, int slots)
    {
        this.Rarity = rarity;
        this.Name = name;
        this.BaseMinDamage = baseMinDamage;
        this.BaseMaxDamage = baseMaxDamage;
        this.slots = new IGem[slots];
    }

    public string Name { get; private set; }

    public WeaponRarity Rarity { get; private set; }

    public int MinDamage
    {
        get
        {
            return this.BaseMinDamage * (int)Rarity + this.Slots
                .Where(g => g != null)
                .Sum(g => g.Strength * 2 + g.Agility);
        }
    }

    public int MaxDamage
    {
        get
        {
            return this.BaseMaxDamage * (int)Rarity + this.Slots
                .Where(g => g != null)
                .Sum(g => g.Strength * 3 + g.Agility * 4);
        }
    }

    public int BaseMinDamage { get; private set; }

    public int BaseMaxDamage { get; private set; }

    public IReadOnlyCollection<IGem> Slots
    {
        get
        {
            return this.slots;
        }
    }

    public void AddGem(int index, IGem gem)
    {
        if (index >= 0 && index < this.Slots.Count)
        {
            this.slots[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < this.Slots.Count)
        {
            this.slots[index] = null;
        }
    }

    public override string ToString()
    {
        int strength = this.Slots
            .Where(g => g != null)
            .Sum(g => g.Strength);

        int agility = this.Slots
            .Where(g => g != null)
            .Sum(g => g.Agility);

        int vitality = this.Slots
            .Where(g => g != null)
            .Sum(g => g.Vitality);

        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}