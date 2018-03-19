using System;
using System.Collections.Generic;
using System.Text;

public abstract class Character
{
    private string name;
    private double baseHealth;
    private double health;
    private double baseArmor;
    private double armor;
    private double abilityPoints;
    private Bag bag;
    private Faction faction;
    private bool isAlive;
    private double restHealMultiplier;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = health;
        this.BaseArmor = armor;
        this.Armor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.IsAlive = true;
    }

    public virtual double RestHealMultiplier
    {
        get { return 0.2; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        private set { isAlive = value; }
    }

    public Faction Faction
    {
        get { return faction; }
        private set { faction = value; }
    }


    public Bag Bag
    {
        get { return bag; }
        private set { bag = value; }
    }


    public double AbilityPoints
    {
        get { return abilityPoints; }
        private set { abilityPoints = value; }
    }

    public double Armor
    {
        get { return armor; }
        private set { armor = value; }
    }


    public double BaseArmor
    {
        get { return baseArmor; }
        private set { baseArmor = value; }
    }


    public double Health
    {
        get { return health; }
        private set { health = value; }
    }


    public double BaseHealth
    {
        get { return baseHealth; }
        private set { baseHealth = value; }
    }


    public string Name
    {
        get { return name; }
        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            name = value;
        }
    }

    public void TakeDamage(double hitPoints)
    {
        this.CheckAlive();

        if (this.Armor < hitPoints)
        {
            hitPoints -= Armor;
            Armor = 0;
            Health -= hitPoints;

            if (Health <= 0)
            {
                this.IsAlive = false;
                this.Health = 0;
            }

            return;
        }

        this.Armor -= hitPoints;
    }

    internal void ReduceHealth(int amount)
    {
        this.Health = Math.Max(0, this.Health - amount);

        if(Health <= 0)
        {
            this.IsAlive = false;
        }
    }

    public void Rest()
    {
        this.CheckAlive();
        this.Health = Math.Min(this.BaseHealth, this.Health + (BaseHealth * RestHealMultiplier));
    }

    public void UseItem(Item item)
    {
        this.CheckAlive();

        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        this.CheckAlive();
        character.CheckAlive();

        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        this.CheckAlive();
        character.CheckAlive();

        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        this.CheckAlive();
        this.Bag.AddItem(item);
    }

    internal void IncreaseHealth(double points)
    {
        this.Health = Math.Min(BaseHealth, Health + points);
    }

    internal void CheckAlive()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }

    internal void RestoreArmor()
    {
        this.Armor = BaseArmor;
    }
}