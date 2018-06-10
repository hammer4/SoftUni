namespace WebServer.Server.Http.Contracts
{
    public interface IHttpHeader
    {
        string Key { get; }

        string Value { get; }
    }
}
