using System;
using System.Collections.Generic;

class SortedSetDemo
{
    static void Main()
    {
        SortedSet<string> set = new SortedSet<string>();
        set.Add("Pesho");
        set.Add("Pesho");
        set.Add("Pesho");
        set.Add("Gosho");
        set.Add("Maria");
        set.Add("Alice");
        Console.WriteLine(string.Join(" ", set));
        // Alice Gosho Maria Pesho

        // Reverse set order
        var reversed = set.Reverse();
        Console.WriteLine(string.Join(" ", reversed));
    }
}
