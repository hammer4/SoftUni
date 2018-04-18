public abstract class Ammunition : IAmmunition
{
    private const int wearLevelMultiplier = 100;

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel {get; private set;}

    public Ammunition()
    {
        WearLevel = Weight * wearLevelMultiplier;
    }

    public void DecreaseWearLevel(double wearAmount)
    {
        WearLevel -= wearAmount;
    }
}