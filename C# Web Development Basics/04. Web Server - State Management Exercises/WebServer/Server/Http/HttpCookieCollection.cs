namespace HTTPServer.Server.Http
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.cookies[cookie.Key] = cookie;
        }

        public void Add(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Add(new HttpCookie(key, value));
        }

        public bool ContainsKey(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            return this.cookies.ContainsKey(key);
        }

        public IEnumerator<HttpCookie> GetEnumerator()
            => this.cookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.cookies.Values.GetEnumerator();

        public HttpCookie Get(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            if (!this.cookies.ContainsKey(key))
            {
                throw new InvalidOperationException($"The given key {key} is not present in the cookies collection.");
            }

            return this.cookies[key];
        }
    }
}
