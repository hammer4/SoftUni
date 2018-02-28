using System;

class Program
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine().Split();
        string[] urls = Console.ReadLine().Split();

        Smartphone smartphone = new Smartphone();

        foreach(var number in numbers)
        {
            Console.WriteLine(smartphone.Call(number));
        }

        foreach(var url in urls)
        {
            Console.WriteLine(smartphone.Browse(url));
        }
    }
}
