using System;
using System.Collections.Generic;
using System.Text;

public class CommandExecutor : IExecutor
{
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }
}