using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server;
using WebServer.Server.Contracts;

namespace WebServer.Application.Views
{
    public class UserDetailsView : IView
    {
        private readonly Model model;

        public UserDetailsView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body>Hello, {model["name"]}!</body>";
        }
    }
}
