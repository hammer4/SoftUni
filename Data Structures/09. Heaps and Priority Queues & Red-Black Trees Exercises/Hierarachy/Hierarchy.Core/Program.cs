
using System;

class Program
{
    static void Main()
    {
        var hierarchy = new Hierarchy<string>("Leonidas");
        hierarchy.Add("Leonidas", "Xena The Princess Warrior");
        hierarchy.Add("Leonidas", "General Protos");
        hierarchy.Add("Xena The Princess Warrior", "Gorok");
        hierarchy.Add("Xena The Princess Warrior", "Bozot");
        hierarchy.Add("General Protos", "Subotli");
        hierarchy.Add("General Protos", "Kira");
        hierarchy.Add("General Protos", "Zaler");

        var children = hierarchy.GetChildren("Leonidas");
        Console.WriteLine(string.Join(", ", children));

        var parent = hierarchy.GetParent("Kira");
        Console.WriteLine(parent);

        hierarchy.Remove("General Protos");
        children = hierarchy.GetChildren("Leonidas");
        Console.WriteLine(string.Join(", ", children));

        foreach (var item in hierarchy)
        {
            Console.WriteLine(item);
        }
    }
}