using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Application.Controllers;
using WebServer.Server.Contracts;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Application
{
    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GetRequestHandler(httpContext => new HomeController().Index()));
            appRouteConfig.AddRoute("/register", new PostRequestHandler(httpContext => new UserController()
            .RegisterPost(httpContext.Request.FormData["name"])));
            appRouteConfig.AddRoute("/register", new GetRequestHandler(httpContext => new UserController().RegisterGet()));
            appRouteConfig.AddRoute("/user/{(?<name>[a-zA-Z]+)}", new GetRequestHandler(httpContext => new UserController()
            .Details(httpContext.Request.UrlParameters["name"])));
        }
    }
}
