using System;

namespace _02._King_s_Gambit.Models
{
    public abstract class Soldier
    {
        public Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void KingUnderAttack();
    }
}