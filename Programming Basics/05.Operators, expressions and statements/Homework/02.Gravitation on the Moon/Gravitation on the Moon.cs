using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        float weight = float.Parse(Console.ReadLine());
        float weightOnMoon = weight * 17/100;
        Console.WriteLine(weightOnMoon);
    }
}