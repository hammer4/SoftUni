using System;

class Program
{
    static void Main(string[] args)
    {
        var scale1 = new Scale<int>(5, 10);
        Console.WriteLine(scale1.GetHeavier());

        var scale2 = new Scale<string>("Man", "Woman");
        Console.WriteLine(scale2.GetHeavier());
    }
}