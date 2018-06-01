using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Handlers;

namespace WebServer.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}
