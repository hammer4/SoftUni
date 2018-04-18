using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int baseRegenerateIncrease = 10;
   
    private const double maxEndurance = 100;

    public string Name {get; }

    public int Age { get; }

    public double Experience { get; private set; }

    private double endurance;
    public double Endurance
    {
        get { return endurance; }
        private set {
            endurance = Math.Min(value, maxEndurance);
        }
    }

    protected abstract double OverallSkillMultiplier { get; } 
    public double OverallSkill => (Age + Experience) * OverallSkillMultiplier;

    protected abstract List<string> WeaponsAllowed { get; }
    public IDictionary<string, IAmmunition> Weapons { get; }

    protected virtual int RegenerateIncrease => baseRegenerateIncrease;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        Weapons = new Dictionary<string, IAmmunition>();
        foreach (var weapon in WeaponsAllowed)
        {
            Weapons.Add(weapon, null);
        }
    }

    public void CompleteMission(IMission mission)
    {
        Experience += mission.EnduranceRequired;
        Endurance -= mission.EnduranceRequired;

        foreach (var weapon in Weapons.Values.Where(w=>w!=null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
            if (weapon.WearLevel <= 0)
                Weapons[weapon.Name] = null;
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }
        
        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void Regenerate()
    {
        this.Endurance += Age + RegenerateIncrease;
    }
    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}