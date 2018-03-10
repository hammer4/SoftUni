namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using System.Linq;

    public class AddPostController : IController
    {
        private enum Command
        {
            AddTitle,
            AddCategory,
            Write,
            Post
        }

        private const int COMMAND_COUNT = 4;
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 18;
        private const int POST_MAX_LENGTH = 660;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public AddPostController()
        {
            this.ResetPost();
        }

        public PostViewModel Post { get; private set; }

        private TextArea TextArea { get; set; }

        public bool Error { get; private set; }

        public void ReadTitle()
        {
            this.Post.Title = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadCategory()
        {
            this.Post.Category = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.AddTitle:
                    this.ReadTitle();
                    return MenuState.AddPost;
                case Command.AddCategory:
                    this.ReadCategory();
                    return MenuState.AddPost;
                case Command.Write:
                    this.TextArea.Write();
                    this.Post.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddPost;
                case Command.Post:
                    bool validPost = PostService.TrySavePost(this.Post);
                    if (!validPost)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.PostAdded;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Post.Author = userName;
            return new AddPostView(this.Post, this.TextArea, this.Error);
        }

        public void ResetPost()
        {
            this.Error = false;
            this.Post = new PostViewModel();
            this.TextArea = new TextArea(centerLeft - 18, centerTop - 7, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }
    }
}
