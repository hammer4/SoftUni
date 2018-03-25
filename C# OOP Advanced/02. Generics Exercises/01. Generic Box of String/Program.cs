using System;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        for(int i=0; i<count; i++)
        {
            string value = Console.ReadLine();
            Box<string> box = new Box<string>(value);

            Console.WriteLine(box);
        }
    }
}