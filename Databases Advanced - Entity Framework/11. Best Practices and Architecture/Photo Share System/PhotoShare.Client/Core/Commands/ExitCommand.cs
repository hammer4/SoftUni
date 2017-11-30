namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Commands.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string command, string[] data)
        {
            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);
            return String.Empty;
        }
    }
}
