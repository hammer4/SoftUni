namespace WebServer.Common
{
    using Contracts;

    public class NotFoundView : IView
    {
        public string View()
        {
            return "<h1>404 This page or resource you are trying to access does not exist :/</h1>";
        }
    }
}
