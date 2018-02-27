using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongException : Exception
{
    public InvalidSongException(string message = "Invalid song.")
        :base(message)
    {
    }
}