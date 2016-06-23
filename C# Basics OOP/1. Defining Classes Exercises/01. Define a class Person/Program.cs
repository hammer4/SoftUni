using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01.Define_a_class_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            Person person1 = new Person
            {
                name = "Pesho",
                age = 20
            };

            Person person2 = new Person();
            person2.name = "Gosho";
            person2.age = 18;

            Person person3 = new Person
            {
                name = "Stamat"
            };
            person3.age = 43;
        }
    }
}
