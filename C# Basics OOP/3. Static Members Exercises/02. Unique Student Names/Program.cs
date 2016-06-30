using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Unique_Student_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while(command != "End")
            {
                Student student = new Student(command);
                StudentGroup.uniqueStudents.Add(student.name);
                command = Console.ReadLine();
            }

            StudentGroup.uniqueStudentNamesCounter = StudentGroup.uniqueStudents.Count;
            Console.WriteLine(StudentGroup.uniqueStudentNamesCounter);
        }
    }
}
