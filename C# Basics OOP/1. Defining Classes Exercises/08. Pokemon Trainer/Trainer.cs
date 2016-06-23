using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Pokemon_Trainer
{
    public class Trainer
    {
        public string name;
        public int badges;
        public List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.badges = 0;
            this.pokemons = new List<Pokemon>();
        }
    }
}
