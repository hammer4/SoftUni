using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while(command != "End")
            {
                Student student = new Student(command);
                command = Console.ReadLine();
            }

            Console.WriteLine(Student.instanceCounter);
        }
    }
}
