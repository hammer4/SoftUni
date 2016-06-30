using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    public class Student
    {
        public string name;
        public static int instanceCounter = 0;

        public Student(string name)
        {
            this.name = name;
            instanceCounter++;
        }
    }
}
