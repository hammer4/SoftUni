using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        int membersCount = int.Parse(Console.ReadLine());
        var family = new Family();

        for(int i=0; i < membersCount; i++)
        {
            var tokens = Console.ReadLine().Split();
            family.AddMember(new Person(tokens[0], int.Parse(tokens[1])));
        }

        Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
    }
}