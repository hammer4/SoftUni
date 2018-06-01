using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Application.Views;
using WebServer.Server.Enums;

namespace WebServer.Server.HTTP.Response
{
    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}
