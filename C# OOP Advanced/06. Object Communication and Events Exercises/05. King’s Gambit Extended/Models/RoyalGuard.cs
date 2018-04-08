using System;

namespace _05._King_s_GambitExtended.Models
{
    public class RoyalGuard : Soldier
    {
        private const int InitialHealth = 3;

        public RoyalGuard(string name)
            : base(name, InitialHealth)
        {
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}