using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Company_Roster
{
    public class Employee
    {
        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email;
        public int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }

        public Employee(string name, decimal salary, string position, string department, string email)
            : this(name, salary, position, department)
        {
            this.email = email;
        }

        public Employee(string name, decimal salary, string position, string department, int age)
            :this(name, salary, position, department)
        {
            this.age = age;
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
            :this(name, salary, position, department)
        {
            this.email = email;
            this.age = age;
        }
    }
}
