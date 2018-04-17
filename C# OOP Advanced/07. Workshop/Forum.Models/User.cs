namespace Forum.DataModels
{
    using System.Collections.Generic;

    public class User
    {
	    public User()
	    {
            this.Posts = new List<int>();
	    }

	    public User(int id, string username, string password)
            :this()
	    {
            this.Id = id;
		    this.Username = username;
		    this.Password = password;
	    }

        public User(int id, string username, string password, IEnumerable<int> posts)
            :this(id, username, password)
        {
            this.Posts.AddRange(new List<int>(posts));
        }

        public int Id { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

	    public List<int> Posts { get; set; } = new List<int>();
    }
}
