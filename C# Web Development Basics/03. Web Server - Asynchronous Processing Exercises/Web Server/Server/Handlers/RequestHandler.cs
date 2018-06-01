using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Handlers.Contracts;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.Handlers
{
    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpContext, IHttpResponse> Func;

        protected RequestHandler(Func<IHttpContext, IHttpResponse> func)
        {
            this.Func = func;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.Func.Invoke(httpContext);
            httpResponse.AddHeader("Content-Type", "text/html");
            return httpResponse;
        }
    }
}
