using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            return "<a href=\"/users/register\">Register user</a>" +
                "<a href=\"/users/all\">All users</a>" +
                "<h3>Hello MVC!</h3>";
        }
    }
}
