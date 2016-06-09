using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Student_Groups
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();
            string command = Console.ReadLine();


            while (command != "End")
            {
                if(command.IndexOf("=>") != -1)
                {
                    towns.Add(ReadTown(command));
                }
                else
                {
                    towns[towns.Count - 1].Students.Add(ReadStudent(command));
                }

                command = Console.ReadLine();
            }

            List<Group> groups = DistributeStudentsIntoGroups(towns);

            Console.WriteLine("Created {0} groups in {1} towns:", groups.Count, towns.Count);

            foreach(Group group in groups.OrderBy(g => g.Town.Name))
            {
                Console.WriteLine("{0} => {1}", group.Town.Name, string.Join(", ", group.Students.Select(s => s.Email).ToList()));
            }
        }

        static Town ReadTown(string input)
        {
            string[] tokens = input.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0].Trim();
            int seatsCount = int.Parse(tokens[1].Trim().Split(' ')[0]);
            List<Student> students = new List<Student>();
            return new Town { Name = name, SeatsCount = seatsCount, Students = students };
        }

        static Student ReadStudent(string input)
        {
            string[] tokens = input.Split('|');
            string name = tokens[0].Trim();
            string email = tokens[1].Trim();
            DateTime registrationDate = DateTime.ParseExact(tokens[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

            return new Student { Name = name, Email = email, RegistrationDate = registrationDate };
        }

        static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();

            foreach(Town town in towns)
            {
                IEnumerable<Student> students = town.Students.OrderBy(s => s.RegistrationDate).ThenBy(s => s.Name).ThenBy(s => s.Email);

                while(students.Any())
                {
                    Group group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }

            return groups;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}
