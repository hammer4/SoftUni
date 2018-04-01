using System;
using System.Collections.Generic;
using System.Text;

public class Reader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}