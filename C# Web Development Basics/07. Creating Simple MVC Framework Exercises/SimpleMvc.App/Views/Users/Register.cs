using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.App.Views.Users
{
    public class Register : IRenderable
    {
        public string Render()
        {
            return "<a href=\"/home/index\">Home</a>" +
                "<h1>Register new user</h1>" + 
                "<form action=\"register\" method=\"POST\">" +
                "<label for=\"username\">Username:</label>" +
                "<br>" +
                "<input type=\"text\" name=\"Username\">" +
                "<br>" +
                "<label for \"password\">Password:</label>" +
                "<br>" +
                "<input type = \"password\" name=\"Password\">" +
                "<br>" +
                "<input type=\"submit\" value = \"Register\">";
        }
    }
}
