namespace HTTPServer.Server.Http.Response
{
    using Common;
    using Enums;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}
