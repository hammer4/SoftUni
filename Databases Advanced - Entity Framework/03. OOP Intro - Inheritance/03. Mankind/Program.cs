using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] tokens = Console.ReadLine().Split();
            var student = new Student(tokens[0], tokens[1], tokens[2]);

            tokens = Console.ReadLine().Split();
            var worker = new Worker(tokens[0], tokens[1], decimal.Parse(tokens[2]), decimal.Parse(tokens[3]));

            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
