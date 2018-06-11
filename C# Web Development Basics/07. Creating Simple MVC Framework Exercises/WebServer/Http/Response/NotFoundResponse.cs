namespace WebServer.Http.Response
{
    using Common;
    using Enums;

    public class NotFoundResponse : ContentResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView().View())
        {
        }
    }
}
