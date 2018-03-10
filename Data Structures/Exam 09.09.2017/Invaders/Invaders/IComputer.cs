using System.Collections.Generic;

public interface IComputer
{
    int Energy { get; }

    void AddInvader(Invader invader);

    void Skip(int turns);

    void DestroyTargetsInRadius(int radius);

    void DestroyHighestPriorityTargets(int n);

    IEnumerable<Invader> Invaders();
}
