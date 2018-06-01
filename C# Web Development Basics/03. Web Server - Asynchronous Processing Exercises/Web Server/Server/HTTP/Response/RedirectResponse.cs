using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Enums;

namespace WebServer.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
            :base()
        {
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader(Location, redirectUrl);
        }
    }
}
