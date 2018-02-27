using System;
using System.Collections.Generic;
using System.Text;

public class Mood
{
    public Mood(string mood)
    {
        this.MoodName = mood;
    }

    public string MoodName { get; private set; }
}
