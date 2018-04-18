
using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory:IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        var type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == name);
        return (IAmmunition)Activator.CreateInstance(type);
    }
}
