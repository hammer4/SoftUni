using System;

class Program
{
    static void Main()
    {
        Console.Write("Sender: ");
        string sender = Console.ReadLine();
        Console.Write("Receiver: ");
        string receiver = Console.ReadLine();
        DateTime currentDateTime = DateTime.Now;
        WriteLetter(sender, receiver, currentDateTime);
    }

    static void WriteLetter(string sender, string receiver, DateTime currentDateTime)
    {
        string body = "I hope I find you in good health.\nI need to inform you that the cheese has run away.";
        Console.WriteLine();
        Console.WriteLine("     Dear {0}, ", receiver);
        Console.WriteLine(body);
        Console.WriteLine("     Sincerely yours, {0}.", sender);
    }
}