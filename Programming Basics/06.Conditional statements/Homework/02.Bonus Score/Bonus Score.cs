using System;

class BonusScore
{
    static void Main()
    {
        int score = int.Parse(Console.ReadLine());
        if (score >=1 && score <= 3)
        {
            score *= 10;
            Console.WriteLine(score);
        }
        else if (score>=4 && score<=6)
        {
            score *= 100;
            Console.WriteLine(score);
        }
        else if (score>=7 && score <=9)
        {
            score *= 1000;
            Console.WriteLine(score);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
}
