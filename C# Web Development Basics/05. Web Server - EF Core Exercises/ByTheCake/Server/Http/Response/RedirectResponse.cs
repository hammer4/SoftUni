namespace HTTPServer.Server.Http.Response
{
    using Common;
    using Enums;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;

            this.Headers.Add(HttpHeader.Location, redirectUrl);
        }
    }
}
