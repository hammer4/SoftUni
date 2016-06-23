using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Google
{
    public class Person
    {
        public string name;
        public Company company;
        public Car car;
        public List<Pokemon> pokemons;
        public List<Parent> parents;
        public List<Child> children;

        public Person(string name)
        {
            this.name = name;
            this.car = null;
            this.pokemons = new List<Pokemon>();
            this.parents = new List<Parent>();
            this.children = new List<Child>();
        }
        /*
        public override string ToString()
        {
            return this.name + "\nCompany:\n" + this.company == null ? "" : this.company.ToString() + "\nCar:\n" +  this.car == null ? "" : this.car.ToString() + "\nPokemon:\n" + string.Join("\n", this.pokemons) + "\nParents:\n" + string.Join("\n", this.parents) + "\nChildren:\n" + string.Join("\n", this.children);
        } */
    }
}
