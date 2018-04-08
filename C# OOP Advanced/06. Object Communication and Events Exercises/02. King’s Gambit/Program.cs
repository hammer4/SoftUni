using _02._King_s_Gambit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._King_s_Gambit
{
    class Program
    {
        static void Main(string[] args)
        {
            var king = new King(Console.ReadLine());
            var soldiers = new List<Soldier>();

            var guardsNames = Console.ReadLine().Split();
            var footmenNames = Console.ReadLine().Split();

            foreach (var name in guardsNames)
            {
                var royalGuard = new RoyalGuard(name);
                soldiers.Add(royalGuard);
                king.UnderAttack += royalGuard.KingUnderAttack;
            }

            foreach (var name in footmenNames)
            {
                var footman = new Footman(name);
                soldiers.Add(footman);
                king.UnderAttack += footman.KingUnderAttack;
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var commandArgs = input.Split();
                var command = commandArgs[0];

                switch (command)
                {
                    case "Kill":
                        var soldierName = commandArgs[1];
                        var soldier = soldiers.FirstOrDefault(s => s.Name == soldierName);
                        king.UnderAttack -= soldier.KingUnderAttack;
                        soldiers.Remove(soldier);
                        break;
                    case "Attack":
                        king.OnAttack();
                        break;
                    default: break;
                }
            }
        }
    }
}
