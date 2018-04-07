using System;
using System.Collections.Generic;
using System.Text;

public interface IExecutor
{
    void ExecuteCommand(ICommand command);
}