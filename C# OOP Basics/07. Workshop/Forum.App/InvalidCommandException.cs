namespace Forum.App
{
    using System;

    public class InvalidCommandException : Exception
    {
        public override string Message => "Invalid command!";
    }
}
