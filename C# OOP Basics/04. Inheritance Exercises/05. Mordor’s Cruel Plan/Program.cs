using System;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();

        Gandalf gandalf = new Gandalf();
        gandalf.TakeFood(input);
        Console.WriteLine(gandalf);
    }
}
