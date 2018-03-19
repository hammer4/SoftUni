using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private Dictionary<string, Character> chars = new Dictionary<string, Character>();
    Stack<Item> pool = new Stack<Item>();
    int lastSurvivorRounds = 0;

    public string JoinParty(string[] args)
    {
        object factionParse;

        if(!Enum.TryParse(typeof(Faction), args[0], out factionParse))
        {
            throw new ArgumentException($"Invalid faction \"{args[0]}\"!");
        }

        Faction faction = (Faction)factionParse;

        if(args[1] != nameof(Cleric) && args[1] != nameof(Warrior))
        {
            throw new ArgumentException($"Invalid character type \"{ args[1] }\"!");
        }

        Character ch = null;
        switch (args[1])
        {
            case nameof(Warrior):
                ch = new Warrior(args[2], faction);
                break;
            case nameof(Cleric):
                ch = new Cleric(args[2], faction);
                break;
        }

        chars.Add(ch.Name, ch);

        return $"{ch.Name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        if(args[0] != nameof(ArmorRepairKit) && args[0] != nameof(HealthPotion) && args[0] != nameof(PoisonPotion))
        {
            throw new ArgumentException($"Invalid item \"{args[0]}\"!");
        }

        Item it = null;

        switch (args[0])
        {
            case nameof(ArmorRepairKit):
                it = new ArmorRepairKit();
                break;
            case nameof(HealthPotion):
                it = new HealthPotion();
                break;
            case nameof(PoisonPotion):
                it = new PoisonPotion();
                break;

        }

        pool.Push(it);

        return $"{args[0]} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        if (!chars.ContainsKey(args[0]))
        {
            throw new ArgumentException($"Character {args[0]} not found!");
        }

        if(pool.Count == 0)
        {
            throw new InvalidOperationException($"No items left in pool!");
        }

        var character = chars[args[0]];
        var item = pool.Pop();

        character.ReceiveItem(item);

        return $"{character.Name} picked up {item.GetType().Name}!";
    }

    public string UseItem(string[] args)
    {
        if (!chars.ContainsKey(args[0]))
        {
            throw new ArgumentException($"Character {args[0]} not found!");
        }

        var character = chars[args[0]];

        var item = character.Bag.GetItem(args[1]);
        character.UseItem(item);

        return $"{character.Name} used {item.GetType().Name}.";
    }

    public string UseItemOn(string[] args)
    {
        if (!chars.ContainsKey(args[0]))
        {
            throw new ArgumentException($"Character {args[0]} not found!");
        }

        if (!chars.ContainsKey(args[1]))
        {
            throw new ArgumentException($"Character {args[1]} not found!");
        }

        var giver = chars[args[0]];
        var receiver = chars[args[1]];

        var item = giver.Bag.GetItem(args[2]);

        giver.UseItemOn(item, receiver);

        return $"{giver.Name} used {item.GetType().Name} on {receiver.Name}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        if (!chars.ContainsKey(args[0]))
        {
            throw new ArgumentException($"Character {args[0]} not found!");
        }

        if (!chars.ContainsKey(args[1]))
        {
            throw new ArgumentException($"Character {args[1]} not found!");
        }

        var giver = chars[args[0]];
        var receiver = chars[args[1]];

        var item = giver.Bag.GetItem(args[2]);

        giver.GiveCharacterItem(item, receiver);

        return $"{giver.Name} gave {receiver.Name} {item.GetType().Name}.";
    }

    public string GetStats()
    {
        var builder = new StringBuilder();

        foreach(var hero in chars.Values.OrderByDescending(h => h.IsAlive).ThenByDescending(h => h.Health))
        {
            builder.AppendLine($"{hero.Name} - HP: {hero.Health}/{hero.BaseHealth}, AP: {hero.Armor}/{hero.BaseArmor}, Status: {(hero.IsAlive ? "Alive" : "Dead")}");
        }

        return builder.ToString().TrimEnd();
    }

    public string Attack(string[] args)
    {
        if (!chars.ContainsKey(args[0]))
        {
            throw new ArgumentException($"Character {args[0]} not found!");
        }

        if (!chars.ContainsKey(args[1]))
        {
            throw new ArgumentException($"Character {args[1]} not found!");
        }

        var attacker = chars[args[0]];
        var receiver = chars[args[1]];

        if(!(attacker is IAttackable))
        {
            throw new ArgumentException($"{attacker.Name} cannot attack!");
        }

        ((IAttackable)attacker).Attack(receiver);

        var builder = new StringBuilder();

        builder.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points!" + 
            $" {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

        if (!receiver.IsAlive)
        {
            builder.AppendLine($"{receiver.Name} is dead!");
        }

        return builder.ToString().TrimEnd();
    }

    public string Heal(string[] args)
    {
        if (!chars.ContainsKey(args[0]))
        {
            throw new ArgumentException($"Character {args[0]} not found!");
        }

        if (!chars.ContainsKey(args[1]))
        {
            throw new ArgumentException($"Character {args[1]} not found!");
        }

        var healer = chars[args[0]];
        var receiver = chars[args[1]];

        if(!(healer is IHealable))
        {
            throw new ArgumentException($"{healer.Name} cannot heal!");
        }

        ((IHealable)healer).Heal(receiver);

        return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
    }

    public string EndTurn(string[] args)
    {
        var aliveHeroes = this.chars.Values
            .Where(h => h.IsAlive)
            .ToList();

        var builder = new StringBuilder();
        foreach(var hero in aliveHeroes)
        {
            var healthBefore = hero.Health;
            hero.Rest();
            builder.AppendLine($"{hero.Name} rests ({healthBefore} => {hero.Health})");
        }

        if(aliveHeroes.Count <= 1)
        {
            this.lastSurvivorRounds++;
        }

        return builder.ToString().TrimEnd();
    }

    public bool IsGameOver()
    {
        return lastSurvivorRounds > 1;
    }

}