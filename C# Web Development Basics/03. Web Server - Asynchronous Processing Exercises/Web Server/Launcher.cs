using System;
using WebServer.Application;
using WebServer.Server;
using WebServer.Server.Contracts;
using WebServer.Server.Routing;
using WebServer.Server.Routing.Contracts;

namespace WebServer
{
    public class Launcher : IRunnable
    {
        private WebServer.Server.WebServer webServer;

        static void Main(string[] args)
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new Server.WebServer(8230, routeConfig);
            this.webServer.Run();
        }
    }
}
