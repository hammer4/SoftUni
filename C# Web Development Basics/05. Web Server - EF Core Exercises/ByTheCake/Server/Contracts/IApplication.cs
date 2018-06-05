namespace HTTPServer.Server.Contracts
{
    using Routing.Contracts;

    public interface IApplication
    {
        void Configure(IAppRouteConfig appRouteConfig);
    }
}
