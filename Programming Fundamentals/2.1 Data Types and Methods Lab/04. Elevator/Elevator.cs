using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int countOfCourses = (int)Math.Ceiling((double)countOfPeople / capacity);
            Console.WriteLine(countOfCourses);
        }
    }
}
