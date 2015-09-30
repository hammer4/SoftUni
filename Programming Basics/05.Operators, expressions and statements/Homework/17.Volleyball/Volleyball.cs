using System;

class Volleyball
{
    static void Main()
    {
        string leap = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        float holidayGames = (float) p * 2 / 3;
        int normalWeekends = 48 - h;
        float gamesNormalWeekends = (float) 3 / 4 * normalWeekends;
        float gamesHomeWeekends = h;
        float games = holidayGames + gamesNormalWeekends + gamesHomeWeekends;
        games = leap == "leap" ? games *(float) 1.15 : games;
        Console.WriteLine((int)games);
    }
}
