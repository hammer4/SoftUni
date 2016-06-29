using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Method_Says_Hello_
{
    public class Person
    {
        public string name;

        public Person(string name)
        {
            this.name = name;
        }

        public string SayHello()
        {
            return String.Format("{0} says \"Hello\"!", this.name);

        }
    }
}
