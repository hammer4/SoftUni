namespace HTTPServer.Server.Common
{
    using Contracts;
    using System;

    public class InternalServerErrorView : IView
    {
        private readonly Exception exception;

        public InternalServerErrorView(Exception exception)
        {
            this.exception = exception;
        }
        
        public string View()
        {
            return $"<h1>{this.exception.Message}</h1><h2>{this.exception.StackTrace}</h2>";
        }
    }
}
