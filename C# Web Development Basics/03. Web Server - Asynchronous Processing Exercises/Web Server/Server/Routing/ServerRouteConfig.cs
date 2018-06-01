using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebServer.Server.Enums;

namespace WebServer.Server.Routing.Contracts
{
    public class ServerRouteConfig : IServerRouteConfig
    {
        private Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();

            this.AddDefaultRequestMethods();

            this.InitializeServerConfig(appRouteConfig);
        }

        public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes => this.routes;

        private void AddDefaultRequestMethods()
        {
            var defaultReqMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();

            foreach (var requestMethod in defaultReqMethods)
            {
                this.routes[requestMethod] = new Dictionary<string, IRoutingContext>();
            }
        }

        private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var appRoute in appRouteConfig.Routes)
            {
                foreach (var handler in appRoute.Value)
                {
                    var args = new List<string>();

                    var parsedRegex = this.ParseRoute(handler.Key, args);

                    var routingContext = new RoutingContext(args, handler.Value);

                    this.routes[appRoute.Key].Add(parsedRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string route, List<string> args)
        {
            if (route == "/")
            {
                return "^/$";
            }

            var parsedRoute = new StringBuilder()
                .Append("^/");

            var tokens = route.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            this.ParseRouteTokens(tokens, args, parsedRoute);

            return parsedRoute.ToString();
        }

        private void ParseRouteTokens(string[] tokens, List<string> args, StringBuilder parsedRoute)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                var end = i == tokens.Length - 1 ? "$" : "/";

                if (!tokens[i].StartsWith('{') && !tokens[i].EndsWith('}'))
                {
                    parsedRoute.Append($"{tokens[i]}{end}");
                    continue;
                }

                var pattern = "<\\w+>";
                var regex = new Regex(pattern);

                var match = regex.Match(tokens[i]);

                if (!match.Success)
                {
                    continue;
                }

                var paramName = match.Groups[0].ToString().Substring(1, match.Groups[0].Length - 2);
                args.Add(paramName);
                parsedRoute.Append($"{tokens[i].ToString().Substring(1, tokens[i].Length - 2)}{end}");
            }
        }
    }
}
