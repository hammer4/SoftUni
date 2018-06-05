namespace HTTPServer.Server.Routing
{
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ServerRouteConfig : IServerRouteConfig
    {
        private readonly IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>>();

            var availableMethods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeRouteConfig(appRouteConfig);
        }

        public IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes => this.routes;
        
        private void InitializeRouteConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var registeredRoute in appRouteConfig.Routes)
            {
                var requestMethod = registeredRoute.Key;
                var routesWithHandlers = registeredRoute.Value;

                foreach (var routeWithHandler in routesWithHandlers)
                {
                    var route = routeWithHandler.Key;
                    var handler = routeWithHandler.Value;

                    var parameters = new List<string>();

                    var parsedRouteRegex = this.ParseRoute(route, parameters);

                    var routingContext = new RoutingContext(handler, parameters);

                    this.routes[requestMethod].Add(parsedRouteRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string route, List<string> parameters)
        {
            if (route == "/")
            {
                return "^/$";
            }

            var result = new StringBuilder();

            result.Append("^/");
            
            var tokens = route.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            this.ParseTokens(tokens, parameters, result);

            return result.ToString();
        }

        private void ParseTokens(string[] tokens, List<string> parameters, StringBuilder result)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                var end = i == tokens.Length - 1 ? "$" : "/";
                var currentToken = tokens[i];

                if (!currentToken.StartsWith('{') && !currentToken.EndsWith('}'))
                {
                    result.Append($"{currentToken}{end}");
                    continue;
                }

                var parameterRegex = new Regex("<\\w+>");
                var parameterMatch = parameterRegex.Match(currentToken);

                if (!parameterMatch.Success)
                {
                    throw new InvalidOperationException($"Route parameter in '{currentToken}' is not valid.");
                }
                
                var match = parameterMatch.Value;
                var parameter = match.Substring(1, match.Length - 2);

                parameters.Add(parameter);

                var currentTokenWithoutCurlyBrackets = currentToken.Substring(1, currentToken.Length - 2);

                result.Append($"{currentTokenWithoutCurlyBrackets}{end}");
            }
        }
    }
}
