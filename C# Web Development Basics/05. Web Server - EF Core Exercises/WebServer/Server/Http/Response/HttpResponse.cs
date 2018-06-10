namespace WebServer.Server.Http.Response
{
    using Contracts;
    using Enums;
    using System.Text;

    public abstract class HttpResponse : IHttpResponse
    {
        private string statusCodeMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
        }

        public HttpStatusCode StatusCode { get; protected set; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public override string ToString()
        {
            var statusCodeNumber = (int)this.StatusCode;

            var response = new StringBuilder();
            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.statusCodeMessage}");
            response.AppendLine(this.Headers.ToString());

            return response.ToString();
        }
    }
}