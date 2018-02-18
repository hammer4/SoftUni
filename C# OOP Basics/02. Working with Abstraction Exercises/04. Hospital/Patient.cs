using System;
using System.Collections.Generic;
using System.Text;

public class Patient
{
    public Patient(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}
