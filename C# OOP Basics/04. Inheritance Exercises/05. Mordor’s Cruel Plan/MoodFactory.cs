using System;
using System.Collections.Generic;
using System.Text;

public static class MoodFactory
{
    public static Mood GenerateMood(int happiness)
    {
        if(happiness < -5)
        {
            return new Mood("Angry");
        }
        else if(happiness <= 0)
        {
            return new Mood("Sad");
        }
        else if(happiness <= 15)
        {
            return new Mood("Happy");
        }
        else
        {
            return new Mood("JavaScript");
        }
    }
}