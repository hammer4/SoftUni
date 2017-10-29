using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Child : Person
{
    public Child(string name, int age)
        :base(name, age)
    {
        this.Age = age;
    }

    protected override int Age
    {
        set
        {
            if(value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }

            base.Age = value;
        }
    }
}
