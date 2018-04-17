namespace Forum.DataModels
{
	using System;
	using System.Collections.Generic;

	public class Post
    {
        public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replies)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.Replies = new List<int>(replies);
        }

        public int Id { get; set; }
        
		public string Title { get; set; }

		public string Content { get; set; }

	    public int CategoryId { get; set; }

		public int AuthorId { get; set; }

		public ICollection<int> Replies { get; set; } = new List<int>();
	}
}
