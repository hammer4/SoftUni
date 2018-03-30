using System;

[SoftUni("Ventsi")]
class StartUp
{
    [SoftUni("Gosho")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}

