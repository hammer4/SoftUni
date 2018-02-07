using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();

            string command;

            while((command = Console.ReadLine()) != "Output")
            {
                string[] commandArgs = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string department = commandArgs[0];
                string doctor = commandArgs[1] + " " + commandArgs[2];
                string patient = commandArgs[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }

                if(departments[department].Count < 60)
                {
                    departments[department].Add(patient);
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }

                doctors[doctor].Add(patient);
            }

            while((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs.Length == 1)
                {
                    departments[commandArgs[0]]
                        .ForEach(Console.WriteLine);
                }
                else if (Char.IsDigit(commandArgs[1][0]))
                {
                    int room = int.Parse(commandArgs[1]);

                    departments[commandArgs[0]]
                        .Skip(3 * (room - 1))
                        .Take(3)
                        .OrderBy(s => s)
                        .ToList()
                        .ForEach(Console.WriteLine);
                }
                else
                {
                    doctors[commandArgs[0] + " " + commandArgs[1]]
                        .OrderBy(s => s)
                        .ToList()
                        .ForEach(Console.WriteLine);
                }
            }
        }
    }
}
