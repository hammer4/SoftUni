namespace HTTPServer.Server.Routing.Contracts
{
    using Handlers;
    using System.Collections.Generic;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler Handler { get; }
    }
}
