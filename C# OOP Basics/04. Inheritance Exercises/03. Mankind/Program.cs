using System;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();

        try
        {
            Student student = new Student(input[0], input[1], input[2]);

            input = Console.ReadLine().Split();
            Worker worker = new Worker(input[0], input[1], decimal.Parse(input[2]), decimal.Parse(input[3]));
            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
