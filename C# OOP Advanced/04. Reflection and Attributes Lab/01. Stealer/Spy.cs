using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static
            | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder builder = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        builder.AppendLine($"Class under investigation: {investigatedClass}");

        foreach(FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return builder.ToString().Trim();
    }
}