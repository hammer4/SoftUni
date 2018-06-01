using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public Dictionary<string, string> FormData { get; }

        public HttpHeaderCollection HeaderCollection { get; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameters { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString
                .Split(Environment.NewLine);

            string[] requestLine = requestLines[0].Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new ArgumentException("Invalid request line.");
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url
                .Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);
            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                var requestFormData = requestLines[requestLines.Length - 1];
                this.ParseQuery(requestFormData, this.FormData);
            }
        }

        private void ParseQuery(string query, IDictionary<string, string> dictionary)
        {
            if (!query.Contains("="))
            {
                return;
            }

            var queryKVPs = query.Split('&');

            foreach (var kvp in queryKVPs)
            {
                var queryArgs = kvp.Split("=");
                if (queryArgs.Length != 2)
                {
                    continue;
                }

                var key = WebUtility.UrlDecode(queryArgs[0]);
                var value = WebUtility.UrlDecode(queryArgs[1]);

                dictionary.Add(key, value);
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            var endIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < endIndex; i++)
            {
                var headerArgs = requestLines[i]
                    .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (headerArgs.Length == 2)
                {
                    var header = new HttpHeader(headerArgs[0], headerArgs[1]);
                    this.HeaderCollection.Add(header);
                }

                if (!this.HeaderCollection.ContainsKey("Host"))
                {
                    throw new ArgumentException();
                }
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("/"))
            {
                return;
            }

            var query = this.Url.Split('/')[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private HttpRequestMethod ParseRequestMethod(string value)
        {
            if (Enum.TryParse(value, out HttpRequestMethod requestMethod))
            {
                return requestMethod;
            }

            throw new ArgumentException();
        }

        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }
    }
}
