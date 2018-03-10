using System;

public interface IInvader : IComparable<IInvader>
{
    int Damage { get; set; }

    int Distance { get; set; }
}
