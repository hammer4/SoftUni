using System;
using System.Collections.Generic;
using System.Text;

public class CharacterFactory
{
    public static Character CreateCharacter(string factio, string type, string name)
    {
        object factionParse;

        if (!Enum.TryParse(typeof(Faction), factio, out factionParse))
        {
            throw new ArgumentException($"Invalid faction \"{factio}\"!");
        }

        Faction faction = (Faction)factionParse;

        switch (type)
        {
            case nameof(Warrior):
                return new Warrior(name, faction);
            case nameof(Cleric):
                return new Cleric(name, faction);
            default:
                throw new ArgumentException($"Invalid character type \"{type}\"!");
        }
    }
}