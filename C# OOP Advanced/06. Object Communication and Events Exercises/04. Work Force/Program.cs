using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        JobList jobs = new JobList();
        List<Employee> employees = new List<Employee>();

        string command;

        while((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();

            switch (tokens[0])
            {
                case "Job":
                    Employee employee = employees.First(e => e.Name == tokens[3]);
                    jobs.AddJob(new Job(tokens[1], int.Parse(tokens[2]), employee));
                    break;
                case "StandardEmployee":
                    employees.Add(new StandardEmployee(tokens[1]));
                    break;
                case "PartTimeEmployee":
                    employees.Add(new PartTimeEmployee(tokens[1]));
                    break;
                case "Pass":
                    jobs.ToList().ForEach(j => j.Update());
                    break;
                case "Status":
                    jobs.ForEach(Console.WriteLine);
                    break;
            }
        }
    }
}