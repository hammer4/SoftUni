using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.Handlers;

namespace WebServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler httpHandler);
    }
}
