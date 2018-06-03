namespace HTTPServer.Server.Exceptions
{
    using System;

    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            : base(message)
        {
        }
    }
}
