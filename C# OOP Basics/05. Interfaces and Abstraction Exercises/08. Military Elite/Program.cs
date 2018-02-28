using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<Soldier> soldiers = new List<Soldier>();

    static void Main(string[] args)
    {
        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();
            string type = tokens[0];

            switch (type)
            {
                case nameof(Private):
                    AddPrivate(tokens);
                    break;
                case nameof(LeutenantGeneral):
                    AddLeutenantGeneral(tokens);
                    break;
                case nameof(Engineer):
                    AddEngineer(tokens);
                    break;
                case nameof(Commando):
                    AddCommando(tokens);
                    break;
                case nameof(Spy):
                    AddSpy(tokens);
                    break;
            }
        }

        soldiers.ForEach(Console.WriteLine);
    }

    private static void AddSpy(string[] tokens)
    {
        Spy spy = new Spy(tokens[1], tokens[2], tokens[3], int.Parse(tokens[4]));

        soldiers.Add(spy);
    }

    private static void AddCommando(string[] tokens)
    {
        try
        {
            Commando commando = new Commando(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]), tokens[5]);

            for(int i=6; i<tokens.Length; i += 2)
            {
                try
                {
                    Mission mission = new Mission(tokens[i], tokens[i + 1]);
                    commando.AddMission(mission);
                }
                catch(ArgumentException)
                {

                }
            }

            soldiers.Add(commando);
        }
        catch (ArgumentException)
        {

        }
    }

    private static void AddEngineer(string[] tokens)
    {
        try
        {
            Engineer engineer = new Engineer(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]), tokens[5]);

            for(int i=6; i<tokens.Length; i+=2)
            {
                Repair repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                engineer.AddRepair(repair);
            }

            soldiers.Add(engineer);
        }
        catch(ArgumentException)
        {

        }
    }

    private static void AddLeutenantGeneral(string[] tokens)
    {
        LeutenantGeneral general = new LeutenantGeneral(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]));

        for(int i = 5; i<tokens.Length; i++)
        {
            Private privat =(Private)soldiers.Single(s => s.Id == tokens[i]);
            general.AddPrivate(privat);
        }

        soldiers.Add(general);
    }

    private static void AddPrivate(string[] tokens)
    {
        Private privat = new Private(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]));

        soldiers.Add(privat);
    }
}
