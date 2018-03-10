using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Computer : IComputer
{
    HashSet<Invader> byInsertion = new HashSet<Invader>();

    private int energy;

    public Computer(int energy)
    {
        if(energy < 0)
        {
            throw new ArgumentException();
        }
        this.energy = energy;
    }

    public int Energy
    {
        get
        {
            return Math.Max(0, energy);
        }
    }

    public void Skip(int turns)
    {
        var toRemove = new List<Invader>();
        foreach(var invader in this.byInsertion)
        {
            invader.Distance -= turns;

            if(invader.Distance <= 0)
            {
                toRemove.Add(invader);

                if(energy >= 0)
                {
                    energy -= invader.Damage;
                }
            }
        }

        toRemove.ForEach(i => byInsertion.Remove(i));
    }

    public void AddInvader(Invader invader)
    {
        this.byInsertion.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        var toDelete = this.byInsertion
            .OrderBy(i => i.Distance)
            .ThenByDescending(i => i.Damage)
            .Take(count)
            .ToList();

        toDelete.ForEach(i => byInsertion.Remove(i));
    }

    public void DestroyTargetsInRadius(int radius)
    {
        var toDelete = this.byInsertion
            .Where(i => i.Distance <= radius)
            .ToList();

        toDelete.ForEach(i => byInsertion.Remove(i));
    }

    public IEnumerable<Invader> Invaders()
    {
        return this.byInsertion;
    }
}
