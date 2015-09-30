using System;

class JorotheFootballPlayer
{
    static void Main()
    {
        string isLeap = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        int nw = 52 - h;
        float games = (float)p / 2 + (float)nw * 2 / 3 + h;
        games = (isLeap[0] == 't') ? games + 3 : games;
        Console.WriteLine((int)games);
    }
}
