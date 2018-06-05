namespace HTTPServer.Server.Handlers
{
    using Common;
    using Contracts;
    using Http.Contracts;
    using Http.Response;
    using Routing.Contracts;
    using Server.Http;
    using System;
    using System.Text.RegularExpressions;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig routeConfig)
        {
            CoreValidator.ThrowIfNull(routeConfig, nameof(routeConfig));

            this.serverRouteConfig = routeConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            try
            {
                // Check if user is authenticated
                var loginPath = "/login";

                if (context.Request.Path != loginPath &&
                    (context.Request.Session == null || 
                    !context.Request.Session.Contains(SessionStore.CurrentUserKey)))
                {
                    return new RedirectResponse(loginPath);
                }

                var requestMethod = context.Request.Method;
                var requestPath = context.Request.Path;
                var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

                foreach (var registeredRoute in registeredRoutes)
                {
                    var routePattern = registeredRoute.Key;
                    var routingContext = registeredRoute.Value;

                    var routeRegex = new Regex(routePattern);
                    var match = routeRegex.Match(requestPath);

                    if (!match.Success)
                    {
                        continue;
                    }

                    var parameters = routingContext.Parameters;

                    foreach (var parameter in parameters)
                    {
                        var parameterValue = match.Groups[parameter].Value;
                        context.Request.AddUrlParameter(parameter, parameterValue);
                    }

                    return routingContext.Handler.Handle(context);
                }
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }

            return new NotFoundResponse();
        }
    }
}
