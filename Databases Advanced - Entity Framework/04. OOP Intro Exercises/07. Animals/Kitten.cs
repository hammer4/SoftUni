using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Kitten : Cat
{
    public Kitten(string name, int age, string gender = "Female")
        : base(name, age, gender)
    {
        this.Gender = "Female";
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}
