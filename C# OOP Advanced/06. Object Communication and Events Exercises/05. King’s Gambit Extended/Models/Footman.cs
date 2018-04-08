using System;

namespace _05._King_s_GambitExtended.Models
{
    public class Footman : Soldier
    {
        private const int InitialHealth = 2;

        public Footman(string name)
            : base(name, InitialHealth)
        {
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}