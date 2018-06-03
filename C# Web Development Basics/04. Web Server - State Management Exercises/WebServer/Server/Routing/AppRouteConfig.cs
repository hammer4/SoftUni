namespace HTTPServer.Server.Routing
{
    using Contracts;
    using Enums;
    using Handlers;
    using HTTPServer.Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>>();

            var availableMethods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes => this.routes;
        
        public void Get(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, HttpRequestMethod.Get, new RequestHandler(handler));
        }

        public void Post(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, HttpRequestMethod.Post, new RequestHandler(handler));
        }

        public void AddRoute(string route, HttpRequestMethod method, RequestHandler handler)
        {
            this.routes[method].Add(route, handler);
        }
    }
}
