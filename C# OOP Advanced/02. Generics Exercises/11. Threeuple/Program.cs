using System;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();
        Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
        Console.WriteLine(tuple1);

        input = Console.ReadLine().Split();
        bool isDrunk = input[2] == "drunk" ? true : false;
        Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
        Console.WriteLine(tuple2);

        input = Console.ReadLine().Split();
        Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
        Console.WriteLine(tuple3);
    }
}