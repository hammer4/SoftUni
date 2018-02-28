using System;
using System.Collections.Generic;
using System.Text;

public interface IPerson
{
    string Name { get; }

    int Age { get; }

    string GetName();
}