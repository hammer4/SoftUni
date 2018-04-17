namespace Forum.Data
{
    using System.Collections.Generic;
    using Forum.DataModels;

    public class ForumData
	{
		public ForumData()
		{
			this.Users = DataMapper.LoadUsers();
			this.Categories = DataMapper.LoadCategories();
			this.Posts = DataMapper.LoadPosts();
			this.Replies = DataMapper.LoadReplies();
		}

		public List<User> Users { get; set; }

		public List<Category> Categories { get; set; }

		public List<Post> Posts { get; set; }

		public List<Reply> Replies { get; set; }

		public void SaveChanges()
		{
			DataMapper.SaveUsers(this.Users);
			DataMapper.SavePosts(this.Posts);
			DataMapper.SaveReplies(this.Replies);
			DataMapper.SaveCategories(this.Categories);
		}
	}
}
