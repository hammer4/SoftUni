using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.Models;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            List<string> result = new List<string>();

            Picture[] pictures = JsonConvert.DeserializeObject<Picture[]>(jsonString);
            var paths = new List<string>();

            foreach (var p in pictures)
            {
                if (p.Size == 0 || String.IsNullOrEmpty(p.Path) || paths.Contains(p.Path))
                {
                    result.Add($"Error: Invalid data.");
                    continue;
                }

                context.Pictures.Add(p);

                paths.Add(p.Path);
                result.Add($"Successfully imported Picture {p.Path}.");
            }

            context.SaveChanges();

            return String.Join(Environment.NewLine, result);
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var result = new List<string>();
            var usernames = new List<string>();

            List<string> paths = context.Pictures
                .Select(p => p.Path)
                .ToList();

            var usersInput = JsonConvert.DeserializeAnonymousType(jsonString, new[] { new {Username = String.Empty,
                Password = String.Empty,
                ProfilePicture = String.Empty } });

            foreach (var u in usersInput)
            {
                if (usernames.Contains(u.Username) || u.Username == null || u.Username.Length > 30 || u.Password == null || u.Password.Length > 20 || !paths.Contains(u.ProfilePicture))
                {
                    result.Add($"Error: Invalid data.");
                    continue;
                }

                var picureId = context.Pictures
                    .SingleOrDefault(p => p.Path == u.ProfilePicture)
                    .Id;

                usernames.Add(u.Username);
                context.Users.Add(new User { Username = u.Username, Password = u.Password, ProfilePictureId = picureId });
                result.Add($"Successfully imported User {u.Username}.");
            }

            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            List<string> result = new List<string>();

            var usernames = context.Users
                .Select(u => u.Username)
                .ToArray();

            var usersFolllowers = JsonConvert.DeserializeAnonymousType(jsonString, new[] { new { User = String.Empty, Follower = String.Empty } });

            foreach (var uf in usersFolllowers)
            {
                if (!usernames.Contains(uf.User) || !usernames.Contains(uf.Follower))
                {
                    result.Add($"Error: Invalid data.");
                    continue;
                }

                var userId = context.Users
                    .SingleOrDefault(u => u.Username == uf.User)
                    .Id;

                var followerId = context.Users
                    .SingleOrDefault(u => u.Username == uf.Follower)
                    .Id;

                if (context.UsersFollowers.Any(usf => usf.UserId == userId && usf.FollowerId == followerId))
                {
                    result.Add($"Error: Invalid data.");
                    continue;
                }

                context.UsersFollowers.Add(new UserFollower { UserId = userId, FollowerId = followerId });

                context.SaveChanges();

                result.Add($"Successfully imported Follower {uf.Follower} to User {uf.User}.");
            }

            return String.Join(Environment.NewLine, result);
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var result = new List<string>();
            XDocument xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            foreach(var post in elements)
            {
                var caption = post.Element("caption").Value;
                var username = post.Element("user").Value;
                var path = post.Element("picture").Value;

                var user = context.Users
                    .SingleOrDefault(u => u.Username == username);

                var picture = context.Pictures
                    .SingleOrDefault(p => p.Path == path);

                if(user == null || picture == null)
                {
                    result.Add($"Error: Invalid data.");
                    continue;
                }

                context.Posts.Add(new Post { Caption = caption, Picture = picture, User = user });
                result.Add($"Successfully imported Post {caption}.");
            }

            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var result = new List<string>();
            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            foreach(var comment in elements)
            {
                var content = comment.Element("content").Value;
                var username = comment.Element("user")?.Value;
                int id = 0;
                    
                if(comment.Element("post") != null)
                {
                    id = int.Parse(comment.Element("post").Attribute("id").Value);
                }

                var user = context.Users
                    .SingleOrDefault(u => u.Username == username);

                var post = context.Posts
                    .SingleOrDefault(p => p.Id == id);

                if(user == null || post == null)
                {
                    result.Add($"Error: Invalid data.");
                    continue;
                }

                context.Comments.Add(new Comment { Content = content, Post = post, User = user });
                result.Add($"Successfully imported Comment {content}.");
            }

            context.SaveChanges();
            return String.Join(Environment.NewLine, result);
        }
    }
}
