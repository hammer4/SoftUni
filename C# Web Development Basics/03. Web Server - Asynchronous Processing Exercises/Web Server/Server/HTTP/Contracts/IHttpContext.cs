using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.HTTP.Contracts
{
    public interface IHttpContext
    {
        IHttpRequest Request { get; }
    }
}
