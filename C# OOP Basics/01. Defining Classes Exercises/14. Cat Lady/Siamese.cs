using System;
using System.Collections.Generic;
using System.Text;

public class Siamese : Cat
{
    private string name;
    private int earSize;

    public Siamese(string name, int earSize)
        :base(name)
    {
        this.earSize = earSize;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {base.Name} {earSize}";
    }
}