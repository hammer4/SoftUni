using SimpleMvc.App.ViewModels;
using SimpleMvc.Framework.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.App.Views.Users
{
    public class All : IRenderable<UsersViewModel>
    {
        public UsersViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">Home</a>");
            sb.AppendLine("<h1>All users</h1>")
                .AppendLine("<ul>");

            foreach (var user in Model.Users)
            {
                sb.AppendLine($"<li><a href=\"/users/profile/?id={user.Key}\">{user.Value}</a></li>");
            }

            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}
