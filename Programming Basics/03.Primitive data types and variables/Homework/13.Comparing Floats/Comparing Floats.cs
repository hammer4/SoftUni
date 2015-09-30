using System;

    class ComparingFloats
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            bool c = eps > Math.Abs(a - b);
            Console.WriteLine(c);
        }
    }
