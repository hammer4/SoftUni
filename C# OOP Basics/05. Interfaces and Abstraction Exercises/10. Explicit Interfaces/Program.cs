using System;

class Program
{
    static void Main(string[] args)
    {
        string command;

        while((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();

            Citizen citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

            Console.WriteLine(citizen.GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}
