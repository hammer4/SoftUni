using System;
using System.Collections.Generic;
using System.Text;

public interface ILogFile
{
    int Size { get; }

    void Write(string content);
}