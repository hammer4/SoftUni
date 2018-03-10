using System;

public class Invader : IInvader
{
    public Invader(int damage, int distance)
    {
        this.Damage = damage;
        this.Distance = distance;
    }

    public int Damage { get; set; }
    public int Distance { get; set; }

    public int CompareTo(IInvader other)
    {
        if (this.Distance.CompareTo(other.Distance) != 0)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        return other.Damage.CompareTo(this.Damage);
    }
}
