namespace WebServer.Server.Http
{
    using Common;
    using Contracts;
    using Enums;
    using Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class HttpRequest : IHttpRequest
    {
        private readonly string requestText;

        public HttpRequest(string requestText)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestText, nameof(requestText));

            this.requestText = requestText;

            this.FormData = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestText);
        }

        public IDictionary<string, string> FormData { get; private set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public string Path { get; private set; }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        public IHttpSession Session { get; set; }

        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestText)
        {
            var requestLines = requestText.Split(Environment.NewLine);

            if (!requestLines.Any())
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            var requestLine = requestLines
                .First()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            this.Method = this.ParseMethod(requestLine.First());
            this.Url = requestLine[1];
            this.Path = this.ParsePath(this.Url);

            this.ParseHeaders(requestLines);
            this.ParseCookies();
            this.ParseParameters();
            this.ParseFormData(requestLines.Last());

            this.SetSession();
        }

        private HttpRequestMethod ParseMethod(string method)
        {
            HttpRequestMethod parsedMethod;
            if (!Enum.TryParse(method, true, out parsedMethod))
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            return parsedMethod;
        }

        private string ParsePath(string url)
            => url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

        private void ParseHeaders(string[] requestLines)
        {
            var emptyLineAfterHeadersIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < emptyLineAfterHeadersIndex; i++)
            {
                var currentLine = requestLines[i];
                var headerParts = currentLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (headerParts.Length != 2)
                {
                    BadRequestException.ThrowFromInvalidRequest();
                }

                var headerKey = headerParts[0];
                var headerValue = headerParts[1].Trim();

                var header = new HttpHeader(headerKey, headerValue);

                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsKey(HttpHeader.Host))
            {
                BadRequestException.ThrowFromInvalidRequest();
            }
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsKey(HttpHeader.Cookie))
            {
                var allCookiesAsString = this.Headers.Get(HttpHeader.Cookie);

                foreach (var cookieAsString in allCookiesAsString)
                {
                    var cookieTokens = cookieAsString
                        .Value
                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(c => c != null)
                        .Where(c => c.Contains('='))
                        .ToList();

                    foreach (var cookieToken in cookieTokens)
                    {
                        var cookiePair = cookieToken
                            .Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(c => c.Trim())
                            .ToList();

                        if (cookiePair.Count == 2)
                        {
                            var cookieKey = cookiePair[0];
                            var cookieValue = cookiePair[1];

                            var httpCookie = new HttpCookie(cookieKey, cookieValue, false);

                            this.Cookies.Add(httpCookie);
                        }
                    }
                }
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            var query = this.Url
                .Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Last();

            this.ParseQuery(query, this.UrlParameters);
        }

        private void ParseFormData(string formDataLine)
        {
            if (this.Method == HttpRequestMethod.Get)
            {
                return;
            }

            this.ParseQuery(formDataLine, this.FormData);
        }

        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if (!query.Contains('='))
            {
                return;
            }

            // username=&password=123 => no RemoveEmptyEntries
            var queryPairs = query.Split(new[] { '&' });

            foreach (var queryPair in queryPairs)
            {
                var queryKvp = queryPair.Split(new[] { '=' });

                if (queryKvp.Length != 2)
                {
                    return;
                }

                var queryKey = WebUtility.UrlDecode(queryKvp[0]);
                var queryValue = WebUtility.UrlDecode(queryKvp[1]);

                dict.Add(queryKey, queryValue);
            }
        }

        private void SetSession()
        {
            // Cookie: MY_SID=ashgdfhaskjd

            if (this.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            {
                var cookie = this.Cookies.Get(SessionStore.SessionCookieKey);
                var sessionId = cookie.Value;

                this.Session = SessionStore.Get(sessionId);
            }
        }

        public override string ToString() => this.requestText;
    }
}