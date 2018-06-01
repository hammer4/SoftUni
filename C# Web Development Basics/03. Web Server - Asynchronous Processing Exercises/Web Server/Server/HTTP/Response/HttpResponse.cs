using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        protected const string Location = "Location";

        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        public HttpStatusCode StatusCode { get; protected set; }

        public IHttpHeaderCollection HeaderCollection { get; private set; }

        public string StatusMessage => this.StatusCode.ToString();

        public string Response => this.BuildResponse();

        public void AddHeader(string key, string value)
        {
            var header = new HttpHeader(key, value);
            this.HeaderCollection.Add(header);
        }

        protected virtual string BuildResponse()
        {
            StringBuilder responseBuilder = new StringBuilder();

            var statusCodeNumber = (int)this.StatusCode;

            responseBuilder.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusMessage}");
            responseBuilder.AppendLine(this.HeaderCollection.ToString());
            responseBuilder.AppendLine();

            return responseBuilder.ToString();
        }
    }
}
