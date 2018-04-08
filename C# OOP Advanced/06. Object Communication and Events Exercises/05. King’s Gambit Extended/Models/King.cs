using System;
using System.Collections.Generic;

namespace _05._King_s_GambitExtended.Models
{
    public delegate void KingUnderAttackHandler();

    public class King
    {
        public event KingUnderAttackHandler UnderAttack;

        private List<Soldier> soldiers;

        public King(string name)
        {
            this.Name = name;
            this.soldiers = new List<Soldier>();
        }

        public string Name { get; private set; }

        public void AddSoldier(Soldier soldier)
        {
            this.soldiers.Add(soldier);
            UnderAttack += soldier.KingUnderAttack;
            soldier.SoldierDead += this.OnSoldierDead;
        }

        public IReadOnlyCollection<Soldier> Soldiers
        {
            get
            {
                return this.soldiers;
            }
        }

        public void OnAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            UnderAttack?.Invoke();
        }

        public void OnSoldierDead(Soldier soldier)
        {
            this.UnderAttack -= soldier.KingUnderAttack;
            this.soldiers.Remove(soldier);
        }
    }
}