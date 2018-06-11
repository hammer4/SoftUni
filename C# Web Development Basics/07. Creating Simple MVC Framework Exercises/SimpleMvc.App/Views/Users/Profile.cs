using SimpleMvc.App.ViewModels;
using SimpleMvc.Framework.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.App.Views.Users
{
    public class Profile : IRenderable<UserProfileViewModel>
    {
        public UserProfileViewModel Model { get; set; }

        public string Render()
        {
            var builder = new StringBuilder();
            builder
                .AppendLine("<a href=\"/home/index\">Home</a>")
                .AppendLine($"<h3>User: {this.Model.Username}</h3>")
                .AppendLine($"<form action=\"profile\" method=\"post\">")
                    .AppendLine("Title: <input type=\"text\" name=\"Title\"/>")
                    .AppendLine("<br/>")
                    .AppendLine("Content: <input type=\"text\" name=\"Content\"/>")
                    .AppendLine("<br/>")
                    .AppendLine($"<input type=\"hidden\" name=\"UserId\" value=\"{this.Model.UserId}\"/>")
                    .AppendLine("<input type=\"submit\" value=\"Add Note\"/>")
                .AppendLine("</form>")
                .AppendLine("<h5>List of notes</h5>")
                .AppendLine("<ul>");

            foreach (var note in this.Model.Notes)
            {
                builder
                    .AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li>");
            }

            builder.AppendLine("</ul>");

            return builder.ToString();
        }
    }
}
