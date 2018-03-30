using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder builder = new StringBuilder();

        foreach(FieldInfo field in classFields)
        {
            builder.AppendLine($"{field.Name} must be private!");
        }

        foreach(MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} have to be public!");
        }

        foreach(MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} have to be private!");
        }

        return builder.ToString().Trim();
    }
}