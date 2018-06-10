namespace WebServer.Server.Handlers
{
    using Common;
    using Contracts;
    using Http;
    using Http.Contracts;
    using System;

    public class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

        public RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));

            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            string sessionIdToSend = null;

            // Create new Session, if no session cookie
            if (!context.Request.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            {
                var sessionId = Guid.NewGuid().ToString();

                context.Request.Session = SessionStore.Get(sessionId);

                sessionIdToSend = sessionId;
            }

            var response = this.handlingFunc(context.Request);

            // Send new Session Cookie
            if (sessionIdToSend != null)
            {
                response.Headers.Add(
                    HttpHeader.SetCookie,
                    $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; Path=/");
            }

            // Send Content-Type Header
            if (!response.Headers.ContainsKey(HttpHeader.ContentType))
            {
                response.Headers.Add(HttpHeader.ContentType, "text/plain");
            }
            
            // Send existing Cookies
            foreach (var cookie in response.Cookies)
            {
                response.Headers.Add(HttpHeader.SetCookie, cookie.ToString());
            }

            return response;
        }
    }
}