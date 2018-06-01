using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Contracts;

namespace WebServer.Application.Views
{
    public class RegisterView : IView
    {
        public string View()
        {
            return
                "<body>" +
                "<form method=\"POST\">" +
                "Name</br>" +
                "<input type=\"text\" name=\"name\" /></br>" +
                "<input type=\"submit\" />" +
                "</form>" +
                "</body>";
        }
    }
}
