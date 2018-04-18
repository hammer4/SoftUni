public interface ISoldierFactory
{
    ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance);
}
