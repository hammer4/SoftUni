namespace Forum.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Forum.DataModels;

    internal static class DataMapper
	{
		private const string DATA_PATH = "../../../../data/";
		private const string CONFIG_PATH = "config.ini";
		private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

		private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

		private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var contents = ReadLines(configPath);

            var config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }
        
        public static List<User> LoadUsers()
		{
			List<User> users = new List<User>();
			var dataLines = ReadLines(config["users"]);

			foreach (var line in dataLines)
			{
				string[] args = line.Split(';');
				int id = int.Parse(args[0]);
				string username = args[1];
				string password = args[2];
				var postIds = args[3]
					.Split(',', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				User user = new User(id, username, password, postIds);
				users.Add(user);
			}

			return users;
		}

		public static void SaveUsers(List<User> users)
		{
			List<string> lines = new List<string>();

			foreach (var user in users)
			{
				const string userFormat = "{0};{1};{2};{3}";
				string line = string.Format(userFormat,
					user.Id,
					user.Username,
					user.Password,
					string.Join(",", user.Posts)
				);

				lines.Add(line);
			}

			WriteLines(config["users"], lines.ToArray());
		}

		public static List<Category> LoadCategories()
		{
			List<Category> categories = new List<Category>();
			var dataLines = ReadLines(config["categories"]);

			foreach (var line in dataLines)
			{
				var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
				var id = int.Parse(args[0]);
				var name = args[1];
                var postIds = args[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Category category = new Category(id, name, postIds);
				categories.Add(category);
			}

			return categories;
		}

		public static void SaveCategories(List<Category> categories)
		{
			List<string> lines = new List<string>();

			foreach (var category in categories)
			{
				const string categoryFormat = "{0};{1};{2}";
				string line = string.Format(categoryFormat,
					category.Id,
					category.Name,
					string.Join(",", category.Posts)
				);

				lines.Add(line);
			}

			WriteLines(config["categories"], lines.ToArray());
		}

		public static List<Post> LoadPosts()
		{
			List<Post> posts = new List<Post>();
			var dataLines = ReadLines(config["posts"]);

			foreach (var line in dataLines)
			{
				var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
				var id = int.Parse(args[0]);
				var title = args[1];
				var content = args[2];
				var categoryId = int.Parse(args[3]);
				var authorId = int.Parse(args[4]);
                var replies = new List<int>();
                if (args.Length == 6)
                {
                    replies.AddRange(args[5].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                }
				Post post = new Post(id, title, content, categoryId, authorId, replies);

				posts.Add(post);
			}

			return posts;
		}

		public static void SavePosts(List<Post> posts)
		{
			List<string> lines = new List<string>();
			foreach (var post in posts)
			{
				const string postFormat = "{0};{1};{2};{3};{4};{5}";
				string line = string.Format(postFormat,
					post.Id,
					post.Title,
					post.Content,
					post.CategoryId,
					post.AuthorId,
					string.Join(",", post.Replies)
				);
				lines.Add(line);
			}

			WriteLines(config["posts"], lines.ToArray());
		}

		public static List<Reply> LoadReplies()
		{
			List<Reply> replies = new List<Reply>();

			var dataLines = ReadLines(config["replies"]);

			foreach (var line in dataLines)
			{
				var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
				var id = int.Parse(args[0]);
				var content = args[1];
				var authorId = int.Parse(args[2]);
				var postId = int.Parse(args[3]);

                replies.Add(new Reply(id, content, authorId, postId));
			}

			return replies;
		}

		public static void SaveReplies(List<Reply> replies)
		{
			List<string> lines = new List<string>();

			foreach (var reply in replies)
			{
				const string replyFormat = "{0};{1};{2};{3}";
				string line = string.Format(replyFormat,
					reply.Id,
					reply.Content,
					reply.AuthorId,
					reply.PostId
				);
				lines.Add(line);
			}

			WriteLines(config["replies"], lines.ToArray());
		}

		private static string[] ReadLines(string path)
		{
			EnsureFile(path);
			var lines = File.ReadAllLines(path);
			return lines;
		}
        
        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
		{
			if (!File.Exists(path))
			{
				File.Create(path).Close();
			}
		}

		private static void WriteLines(string path, string[] lines)
		{
			File.WriteAllLines(path, lines);
		}

	}
}
