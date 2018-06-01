using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Enums;

namespace WebServer.Server.HTTP.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection HeaderCollection { get; }

        string StatusMessage { get; }

        string Response { get; }

        void AddHeader(string key, string value);
    }
}
