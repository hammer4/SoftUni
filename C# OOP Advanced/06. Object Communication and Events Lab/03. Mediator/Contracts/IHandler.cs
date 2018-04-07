using System;
using System.Collections.Generic;
using System.Text;

public interface IHandler
{
    void Handle(LogType type, string message);

    void SetSuccessor(IHandler handler);
}