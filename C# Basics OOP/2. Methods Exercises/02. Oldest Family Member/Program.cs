using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();
            int count = int.Parse(Console.ReadLine());
            for(int i=0; i<count; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                family.AddMember(new Person(name, age));
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine("{0} {1}", oldestMember.name, oldestMember.age);
        }
    }
}
