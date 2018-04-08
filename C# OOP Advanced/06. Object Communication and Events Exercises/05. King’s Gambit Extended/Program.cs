using _05._King_s_GambitExtended.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._King_s_GambitExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            string kingName = Console.ReadLine();
            var king = new King(kingName);

            var guardsNames = Console.ReadLine().Split();
            var footmenNames = Console.ReadLine().Split();

            foreach (var name in guardsNames)
            {
                var royalGuard = new RoyalGuard(name);
                king.AddSoldier(royalGuard);
            }

            foreach (var name in footmenNames)
            {
                var footman = new Footman(name);
                king.AddSoldier(footman);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var commandArgs = input.Split();
                var command = commandArgs[0];

                switch (command)
                {
                    case "Kill":
                        var soldierName = commandArgs[1];
                        var soldier = king.Soldiers.FirstOrDefault(s => s.Name == soldierName);
                        soldier.TakeAttack();
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
