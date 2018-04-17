namespace Forum.App.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;

    public class ViewCategoryMenu : Menu, IIdHoldingMenu, IPaginatedMenu
	{
		private const int pageSize = 10;
		private const int categoryNameLength = 36;

		private ILabelFactory labelFactory;
		private IPostService postService;
        private ICommandFactory commandFactory;

		private int categoryId;
		private int currentPage;
		private IPostInfoViewModel[] posts;

        public ViewCategoryMenu(ILabelFactory labelFactory, IPostService postService, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        private int LastPage => this.posts.Length / 11;

        private bool IsFirstPage => this.currentPage == 0;

        private bool IsLastPage => this.currentPage == this.LastPage;

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			string categoryName = this.postService.GetCategoryName(this.categoryId);

			string[] labelContent = new string[] { categoryName, "Name", "Replies" };
			Position[] labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // Category name
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left + 12, consoleCenter.Top - 10), // Replies
            };

			this.Labels = new ILabel[labelContent.Length];

			for (int i = 0; i < this.Labels.Length; i++)
			{
				this.Labels[i] = this.labelFactory.CreateLabel(labelContent[i], labelPositions[i]);
			}
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			string[] defaultButtonContent = new string[] { "Back", "Previous Page", "Next Page" };
			Position[] defaultButtonPositions = new Position[]
			{
				new Position(consoleCenter.Left + 15, consoleCenter.Top - 12), // Back   
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 12), // Previous Page
                new Position(consoleCenter.Left + 10, consoleCenter.Top + 12), // Next Page
            };

			Position[] categoryButtonPositions = new Position[pageSize];

			for (int i = 0; i < pageSize; i++)
			{
				categoryButtonPositions[i] = new Position(consoleCenter.Left - 18, consoleCenter.Top - 8 + i * 2);
			}

			IList<IButton> buttons = new List<IButton>();
			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[0], defaultButtonPositions[0]));

			for (int i = 0; i < categoryButtonPositions.Length; i++)
			{
				IPostInfoViewModel post = null;

				int categoryIndex = i + this.currentPage * pageSize;

				if (categoryIndex < this.posts.Length)
				{
					post = this.posts[categoryIndex];
				}

				string postsCount = post?.ReplyCount.ToString();
				string buffer = new string(' ', categoryNameLength - post?.Title.Length ?? 0 - postsCount?.Length ?? 0);
				string buttonText = post?.Title + buffer + postsCount;

				IButton button = this.labelFactory.CreateButton(buttonText, categoryButtonPositions[i], post == null);

				buttons.Add(button);
			}

			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[1], defaultButtonPositions[1], this.IsFirstPage));
			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[2], defaultButtonPositions[2], this.IsLastPage));

			this.Buttons = buttons.ToArray();
		}

		public override IMenu ExecuteCommand()
		{
            ICommand command = null;

            int actualIndex = this.currentPage * 10 + this.currentIndex - 1;
            string postId = null;

            if(this.currentIndex > 0 && this.currentIndex < 10)
            {
                postId = this.posts[actualIndex].Id.ToString();
                command = this.commandFactory.CreateCommand("ViewPostMenu");
            }
            else
            {
                command = this.commandFactory.CreateCommand(String.Join("", this.CurrentOption.Text.Split()));
            }

            return command.Execute(postId);
		}

		public void ChangePage(bool forward = true)
		{
            this.currentPage += forward ? 1 : -1;
            this.currentIndex = 0;
            this.Open();
        }

		public void SetId(int id)
		{
            this.categoryId = id;

            this.Open();
		}

        public override void Open()
        {
            this.LoadPosts();

            base.Open();
        }

        private void LoadPosts()
        {
            this.posts = this.postService.GetCategoryPostsInfo(this.categoryId).ToArray();
        }
    }
}
