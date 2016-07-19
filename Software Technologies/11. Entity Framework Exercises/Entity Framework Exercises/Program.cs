using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListAllPosts();
            //ListAllUsers();
            //ListTitleAndBodyFromPosts();
            //OrderData();
            //OrderByTwoColumns();
            //SelectAuthors();
            //JoinsAuthorsWithTitles();
            //SelectAuthorOfSpecificPost();
            //OrderPostsAuthors();
            //CreateData();
            //UpdateData();
            //DeleteCommentById();
            //DeletePostById();
        }

        private static void DeletePostById()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            Post postInfo = blogDbContext.Posts.Single(post => post.Id == 33);
            blogDbContext.Comments.RemoveRange(postInfo.Comments);
            postInfo.Tags.Clear();
            blogDbContext.Posts.Remove(postInfo);
            blogDbContext.SaveChanges();
            Console.WriteLine("Post #{0} deleted successfully", postInfo.Id);
        }

        private static void DeleteCommentById()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            Comment commentInfo = blogDbContext.Comments.Single(comment => comment.Id == 1);
            blogDbContext.Comments.Remove(commentInfo);
            blogDbContext.SaveChanges();
            Console.WriteLine(@"Comment #{0} deleted", commentInfo.Id);
        }

        private static void UpdateData()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            User userInfo = blogDbContext.Users.Single(user => user.UserName == "GBotev");
            string oldName = userInfo.FullName;
            userInfo.FullName = "Georgi Botev";
            blogDbContext.SaveChanges();
            Console.WriteLine(@"User '{0}' has been renamed to '{1}'", oldName, userInfo.FullName);
        }

        private static void CreateData()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            Post post = new Post()
            {
                AuthorId = 2,
                Title = "Random title",
                Body = "Random content",
                Date = DateTime.Now
            };
            blogDbContext.Posts.Add(post);
            blogDbContext.SaveChanges();

            Console.WriteLine("Post #{0} Created!", post.Id);
        }

        private static void OrderPostsAuthors()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            var postAuthors = blogDbContext.Users.Where(user => user.Posts.Count > 0).OrderByDescending(user => user.Id).Select(user => new
            {
                user.UserName,
                user.FullName
            }).ToList();

            foreach (var user in postAuthors)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full Name: {0}", user.FullName);
            }
        }

        private static void SelectAuthorOfSpecificPost()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            var author = blogDbContext.Users.SelectMany(user => user.Posts, (user, post) => new { user.UserName, user.FullName, post.Id }).Single(post => post.Id == 4);

            Console.WriteLine("Username: {0}", author.UserName);
            Console.WriteLine("Full name: {0}", author.FullName);
            Console.WriteLine();
        }

        private static void JoinsAuthorsWithTitles()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            var users = blogDbContext.Users.SelectMany(user => user.Posts, (user, post) => new { user.UserName, post.Title });

            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Post Title: {0}", user.Title);
                Console.WriteLine();
            }
        }

        private static void SelectAuthors()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            List<User> users = blogDbContext.Users.Select(user => user).Where(user => user.Posts.Count > 0).ToList();

            foreach (User user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full Name: {0}", user.FullName);
                Console.WriteLine("Posts Count: {0}", user.Posts.Count);
                Console.WriteLine();
            }
        }

        private static void OrderByTwoColumns()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            var users = blogDbContext.Users.Select(user => new
            {
                user.UserName,
                user.FullName
            }).OrderByDescending(user => user.UserName).ThenByDescending(user => user.FullName).ToList();

            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full Name: {0}", user.FullName);
                Console.WriteLine();
            }
        }

        private static void OrderData()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            var users = blogDbContext.Users.Select(user => new
            {
                user.UserName,
                user.FullName
            }).OrderBy(user => user.UserName).ToList();

            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full Name: {0}", user.FullName);
                Console.WriteLine();
            }
        }

        private static void ListTitleAndBodyFromPosts()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            var posts = blogDbContext.Posts.Select(post => new
            {
                post.Title,
                post.Body
            }).ToList();

            foreach (var post in posts)
            {
                Console.WriteLine("Title: {0}", post.Title);
                Console.WriteLine("Content: {0}", post.Body);
                Console.WriteLine();
            }
        }

        private static void ListAllUsers()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            List<User> users = blogDbContext.Users.Select(user => user).ToList();

            foreach (User user in users)
            {
                Console.WriteLine("ID: {0}", user.Id);
                Console.WriteLine("Name: {0}", user.FullName);
                Console.WriteLine("Comments Count: {0}", user.Comments.Count);
                Console.WriteLine("Posts Count: {0}", user.Posts.Count);
                Console.WriteLine();
            }
        }

        private static void ListAllPosts()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            List<Post> posts = blogDbContext.Posts.Select(post => post).ToList();

            foreach (Post post in posts)
            {
                Console.WriteLine("Title: {0}", post.Title);
                Console.WriteLine("AuthorID: {0}", post.AuthorId);
                Console.WriteLine("Comments Count: {0}", post.Comments.Count);
                Console.WriteLine("Tags Count: {0}", post.Tags.Count);
                Console.WriteLine();
            }
        }
    }
}
