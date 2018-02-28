using System;

class Program
{
    static void Main(string[] args)
    {
        string driver = Console.ReadLine();
        var ferrari = new Ferrari(driver);
        Console.WriteLine(ferrari);
    }
}
