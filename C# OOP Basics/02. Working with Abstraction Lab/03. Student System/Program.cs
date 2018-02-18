using System;

class Program
{
    static void Main(string[] args)
    {
        StudentSystem system = new StudentSystem();

        while (true)
        {
            string command = Console.ReadLine();
            system.ParseCommand(command);
        }
    }
}
