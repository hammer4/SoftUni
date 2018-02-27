using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException(string message = "Song name should be between 3 and 30 symbols.")
        :base(message)
    {
    }
}