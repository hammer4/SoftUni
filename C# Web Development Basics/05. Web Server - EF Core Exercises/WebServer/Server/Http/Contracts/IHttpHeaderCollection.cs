namespace WebServer.Server.Http.Contracts
{
    using System.Collections.Generic;

    public interface IHttpHeaderCollection : IEnumerable<ICollection<IHttpHeader>>
    {
        void Add(IHttpHeader header);

        void Add(string key, string value);

        bool ContainsKey(string key);

        ICollection<IHttpHeader> Get(string key);
    }
}