using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Contracts;

namespace WebServer.Application.Views
{
    public class NotFoundView : IView
    {
        public string View()
        {
            return "<body><h1>Not found!</h1></body>";
        }
    }
}
