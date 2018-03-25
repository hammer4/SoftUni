using System;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        for(int i=0; i<count; i++)
        {
            int value = int.Parse(Console.ReadLine());
            var box = new Box<int>(value);

            Console.WriteLine(box);
        }
    }
}