namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Utilities;

    public class ExitCommand
    {
        public string Execute(string[] commandArgs)
        {
            Check.CheckLength(0, commandArgs);

            Environment.Exit(0);

            return "Good bye!";
        }
    }
}