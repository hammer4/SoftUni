using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Song
{
    private string name;
    private string artist;
    private int minutes;
    private int seconds;

    public Song(string[] tokens)
    {
        ValidateArgs(tokens);
        this.Artist = tokens[0];
        this.Name = tokens[1];
        int[] lengthArgs = ValidateLength(tokens[2]);
        this.Minutes = lengthArgs[0];
        this.Seconds = lengthArgs[1];
    }

    private string Name
    {
        set
        {
            if(value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            this.name = value;
        }
    }

    private string Artist
    {
        set
        {
            if(value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            this.artist = value;
        }
    }

    private int Minutes
    {
        set
        {
            if(value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }

            this.minutes = value;
        }
    }

    private int Seconds
    {
        set
        {
            if(value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            this.seconds = value;
        }
    }

    private void ValidateArgs(string[] tokens)
    {
        if(tokens.Length != 3)
        {
            throw new InvalidSongException();
        }
    }

    private int[] ValidateLength(string length)
    {
        var tokens = length.Split(':');
        if (tokens.Length != 2 || tokens.Any(t => !t.All(c => Char.IsDigit(c))))
        {
            throw new InvalidSongLengthException();
        }

        return tokens.Select(int.Parse).ToArray();
    }

    public int GetLengthInSeconds()
    {
        return this.minutes * 60 + this.seconds;
    }
}