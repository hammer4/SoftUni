using System;
using System.Collections.Generic;
using System.Text;

public abstract class Logger : IHandler
{
    private IHandler successor;

    public abstract void Handle(LogType type, string message);

    public void SetSuccessor(IHandler successor)
    {
        this.successor = successor;
    }

    protected void PassToSuccessor(LogType type, string message)
    {
        if(this.successor != null)
        {
            this.successor.Handle(type, message);
        }
    }
}