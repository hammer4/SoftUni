using System;

class Triangle
{
    static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());

        double dab = Math.Sqrt((bX - aX) * (bX - aX) + (bY - aY) * (bY - aY));
        double dbc = Math.Sqrt((cX - bX) * (cX - bX) + (cY - bY) * (cY - bY));
        double dca = Math.Sqrt((aX - cX) * (aX - cX) + (aY - cY) * (aY - cY));

        double p = (dab + dbc + dca) / 2;

        double area = Math.Sqrt(p * (p - dab) * (p - dbc) * (p - dca));

        if (dab+dbc>dca && dab+dca>dbc && dbc+dca>dab)
        {
            Console.WriteLine("Yes");
            Console.WriteLine("{0:F2}", area);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}", dab);
        }
    }
}
