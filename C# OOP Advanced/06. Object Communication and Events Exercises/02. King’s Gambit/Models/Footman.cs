using System;

namespace _02._King_s_Gambit.Models
{
    public class Footman : Soldier
    {
        public Footman(string name)
            : base(name)
        {
        }

        public override void KingUnderAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}