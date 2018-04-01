using System;
using System.Collections.Generic;
using System.Text;

public class EndCommand : Command
{
    public EndCommand(string[] data) 
        : base(data)
    {
    }

    public override void Execute()
    {
        Environment.Exit(0);
    }
}