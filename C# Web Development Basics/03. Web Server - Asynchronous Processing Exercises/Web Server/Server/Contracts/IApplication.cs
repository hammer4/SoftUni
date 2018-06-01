using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Server.Contracts
{
    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}
