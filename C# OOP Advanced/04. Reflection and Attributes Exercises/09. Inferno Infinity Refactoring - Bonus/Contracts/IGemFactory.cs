using System;
using System.Collections.Generic;
using System.Text;

public interface IGemFactory
{
    IGem CreateGem(string clarity, string gemType);
}