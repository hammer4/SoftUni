using System;
using Newtonsoft.Json;

using Instagraph.Data;
using System.Linq;
using System.Xml.Linq;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new
                {
                    p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                });

            var json = JsonConvert.SerializeObject(posts);

            return json;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Select(f => f.Follower)
                            .Any(fol => fol == c.User))))
                .Select(u => new
                {
                    u.Username,
                    Followers = u.Followers.Count
                })
                .ToArray();
                 

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    u.Username,
                    MostComments = u.Posts.Any() ?
                        u.Posts
                        .OrderByDescending(p => p.Comments.Count)
                        .FirstOrDefault()
                        .Comments
                        .Count : 0
                })
                .OrderByDescending(o => o.MostComments)
                .ThenBy(o => o.Username);

            var xDoc = new XDocument();
            xDoc.Add(new XElement("users"));

            foreach(var u in users)
            {
                var user = new XElement("user");
                user.Add(new XElement("Username", u.Username));
                user.Add(new XElement("MostComments", u.MostComments));

                xDoc.Element("users").Add(user);
            }

            return xDoc.ToString();
        }
    }
}
