using System;

class Program
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.RevealPrivateMethods("Hacker");
        Console.WriteLine(result);
    }
}