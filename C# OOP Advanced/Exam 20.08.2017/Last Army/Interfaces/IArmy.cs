using System.Collections.Generic;

public interface IArmy
{
    IReadOnlyList<ISoldier> Soldiers { get; }

    void AddSoldier(ISoldier soldier);

    void RegenerateTeam(string soldierType);
}