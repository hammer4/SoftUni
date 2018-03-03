using System;
using System.Collections.Generic;
using System.Text;

public static class AnimalFactory
{
    public static Animal Create(string[] args)
    {
        string type = args[0];

        switch (type)
        {
            case nameof(Owl):
                return new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
            case nameof(Hen):
                return new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
            case nameof(Cat):
                return new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
            case nameof(Tiger):
                return new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
            case nameof(Dog):
                return new Dog(args[1], double.Parse(args[2]), args[3]);
            case nameof(Mouse):
                return new Mouse(args[1], double.Parse(args[2]), args[3]);
            default:
                throw new ArgumentException($"{type} is not a valid Animal type.");
        }
    }
}