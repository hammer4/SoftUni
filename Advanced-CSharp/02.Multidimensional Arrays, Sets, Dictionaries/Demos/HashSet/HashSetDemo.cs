using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> set = new HashSet<string>();
        set.Add("Pesho");
        set.Add("Pesho");
        set.Add("Gosho");
        set.Add("Alice");
        Console.WriteLine(string.Join(" ", set));
        // Pesho Gosho Alice

        Console.WriteLine(set.Contains("Georgi")); // false
        Console.WriteLine(set.Contains("Pesho")); // true
        set.Remove("Pesho");
        Console.WriteLine(set.Count); // 2

    }
}
