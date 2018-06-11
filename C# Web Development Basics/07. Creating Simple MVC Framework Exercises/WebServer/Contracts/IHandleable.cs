using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Http.Contracts;

namespace WebServer.Contracts
{
    public interface IHandleable
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
