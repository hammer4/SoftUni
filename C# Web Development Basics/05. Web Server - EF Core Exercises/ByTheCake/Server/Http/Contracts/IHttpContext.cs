namespace HTTPServer.Server.Http.Contracts
{
    public interface IHttpContext
    {
        IHttpRequest Request { get; }
    }
}
