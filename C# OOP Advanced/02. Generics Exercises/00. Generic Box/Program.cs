using System;

class Program
{
    static void Main(string[] args)
    {
        var box1 = new Box<int>(123123);
        var box2 = new Box<string>("life in a box");

        Console.WriteLine(box1);
        Console.WriteLine(box2);
    }
}