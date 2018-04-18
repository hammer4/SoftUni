public interface IAmmunition
{
    string Name { get; }

    double Weight { get; }

    double WearLevel { get; }

    void DecreaseWearLevel(double wearAmount);
}
