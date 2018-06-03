namespace HTTPServer.Server.Routing.Contracts
{
    using Enums;
    using System.Collections.Generic;

    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }
    }
}
