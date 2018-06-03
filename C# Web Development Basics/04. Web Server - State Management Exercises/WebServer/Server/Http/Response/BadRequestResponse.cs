namespace HTTPServer.Server.Http.Response
{
    using Enums;

    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
