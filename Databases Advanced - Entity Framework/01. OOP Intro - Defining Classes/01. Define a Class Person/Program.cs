using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Type personType = typeof(Person);
        PropertyInfo[] properties = personType.GetProperties
            (BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(properties.Length);

        Person pesho = new Person();
        pesho.Name = "Pesho";
        pesho.Age = 20;

        Person gosho = new Person
        {
            Name = "Gosho",
            Age = 18
        };

        Person stamat = new Person
        {
            Name = "Stamat"
        };
        stamat.Age = 43;
    }
}
