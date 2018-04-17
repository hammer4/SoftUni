namespace Forum.App.Menus
{
	using System.Linq;
	using System.Collections.Generic;

	using Models;
	using Contracts;
    using System;

    public class ViewPostMenu : Menu, IIdHoldingMenu
	{
		private const int leftOffset = 18;
		private const int topOffset = 7;

		private ILabelFactory labelFactory;
		private ISession session;

		private IForumViewEngine viewEngine;
        private ICommandFactory commandFactory;
        private IPostService postService;
		
		private int postId;
		private IPostViewModel post;

        public ViewPostMenu(IPostService postService, ICommandFactory commandFactory, ILabelFactory labelFactory, ISession session, IForumViewEngine viewEngine)
        {
            this.postService = postService;
            this.labelFactory = labelFactory;
            this.session = session;
            this.commandFactory = commandFactory;
            this.viewEngine = viewEngine;
        }

		public override void Open()
		{		
			this.LoadPost();
			this.ExtendBuffer();

			Position consoleCenter = Position.ConsoleCenter();

			InitializeStaticLabels(consoleCenter);

			InitializeButtons(consoleCenter);

			// Add replies
			int currentRow = consoleCenter.Top - (consoleCenter.Top - topOffset - 3 - this.post.Content.Length) + 1;

			Position repliesStartPosition = new Position(consoleCenter.Left - leftOffset, currentRow++);
			int repliesCount = this.post.Replies.Length;

			ICollection<ILabel> replyLabels = new List<ILabel>();

			replyLabels.Add(this.labelFactory.CreateLabel($"Replies: {repliesCount}", repliesStartPosition));

			foreach (var reply in this.post.Replies)
			{
				Position replyAuthorPosition = new Position(repliesStartPosition.Left, ++currentRow);

				replyLabels.Add(this.labelFactory.CreateLabel(reply.Author, replyAuthorPosition));

				foreach (var line in reply.Content)
				{
					Position rowPosition = new Position(repliesStartPosition.Left, ++currentRow);
					replyLabels.Add(this.labelFactory.CreateLabel(line, rowPosition));
				}
				currentRow++;
			}

			this.Labels = this.Labels.Concat(replyLabels).ToArray();
		}

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			Position titlePosition =
				new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 10);
			Position authorPosition =
				new Position(consoleCenter.Left - this.post.Author.Length, consoleCenter.Top - 9);

			var labels = new List<ILabel>()
			{
				this.labelFactory.CreateLabel(this.post.Title, titlePosition),
				this.labelFactory.CreateLabel($"Author: {this.post.Author}", authorPosition),
			};

			int leftPosition = consoleCenter.Left - leftOffset;

			int lineCount = this.post.Content.Length;

			// Add post contents
			for (int i = 0; i < lineCount; i++)
			{
				Position position = new Position(leftPosition, consoleCenter.Top - (topOffset - i));
				ILabel label = this.labelFactory.CreateLabel(this.post.Content[i], position);
				labels.Add(label);
			}

			this.Labels = labels.ToArray();
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			this.Buttons = new IButton[2];

			this.Buttons[0] = this.labelFactory.CreateButton("Back",
				new Position(consoleCenter.Left + 15, consoleCenter.Top - 3));
			this.Buttons[1] = this.labelFactory.CreateButton("Add Reply",
				new Position(consoleCenter.Left + 10, consoleCenter.Top - 4), !this.session.IsLoggedIn);
		}

		public void SetId(int id)
		{
            this.postId = id;

            this.Open();
		}

		private void LoadPost()
		{
            this.post = this.postService.GetPostViewModel(this.postId);
		}

		public override IMenu ExecuteCommand()
		{
            string commandName = String.Join("", this.CurrentOption.Text.Split());
            ICommand command = this.commandFactory.CreateCommand(commandName);
            IMenu view = command.Execute(this.postId.ToString());

            this.viewEngine.ResetBuffer();

            return view;
        }

		private void ExtendBuffer()
		{
			int totalLines = 13 + this.post.Content.Length;

			foreach (var reply in this.post.Replies)
			{
				totalLines += 2 + reply.Content.Length;
			}

			if (totalLines > 30)
			{
				viewEngine.SetBufferHeight(totalLines);
			}
		}
	}
}
