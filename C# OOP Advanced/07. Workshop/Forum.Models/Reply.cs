namespace Forum.DataModels
{
	public class Reply
    {
	    public Reply()
	    {
	    }

	    public Reply(string content)
	    {
		    this.Content = content;
	    }

	    public Reply(string content, int authorId)
			: this(content)
	    {
		    this.AuthorId = authorId;
	    }

        public Reply(int id, string content, int authorId, int postId)
            : this(content, authorId)
        {
            this.Id = id;
            this.PostId = postId;
        }

        public int Id { get; set; }

		public string Content { get; set; }

		public int AuthorId { get; set; }

		public int PostId { get; set; }
    }
}
