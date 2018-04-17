namespace Forum.App.Menus
{
	using Models;
	using Contracts;
    using System;

    public class AddPostMenu : Menu, ITextAreaMenu
	{
		private ILabelFactory labelFactory;
		private ITextAreaFactory textAreaFactory;
		private IForumReader reader;
        private ICommandFactory commandFactory;

		private bool error;

        public AddPostMenu(ILabelFactory labelFactory, ITextAreaFactory textAreaFactory, IForumReader forumReader, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.textAreaFactory = textAreaFactory;
            this.reader = forumReader;
            this.commandFactory = commandFactory;

            this.InitializeTextArea();
            this.Open();
        }

		private string TitleInput => this.Buttons[0].Text.TrimStart();

		private string CategoryInput => this.Buttons[1].Text.TrimStart();
		
		public ITextInputArea TextArea { get; private set; }

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			string[] labelContents = new string[] { "All fields must be filled!", "Title:", "Category:", "", "" };
			Position[] labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 14), // Error: 
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // Title: 
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Category:
                new Position(consoleCenter.Left - 9, consoleCenter.Top - 12),  // Title: 
                new Position(consoleCenter.Left - 7, consoleCenter.Top - 10),  // Category:
            };

			this.Labels = new ILabel[labelContents.Length];
			this.Labels[0] = this.labelFactory.CreateLabel(labelContents[0], labelPositions[0], !error);

			for (int i = 1; i < this.Labels.Length; i++)
			{
				this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
			}
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			string[] buttonContents = new string[] { "Write", "Post" };
			Position[] fieldPositions = new Position[]
			{
				new Position(consoleCenter.Left - 10, consoleCenter.Top - 12), // Title: 
                new Position(consoleCenter.Left - 8, consoleCenter.Top - 10),  // Category:
            };

			Position[] buttonPositions = new Position[]
			{
				new Position(consoleCenter.Left + 14, consoleCenter.Top - 8),  // Write
                new Position(consoleCenter.Left + 14, consoleCenter.Top + 12)  // Post
            };

			this.Buttons = new IButton[fieldPositions.Length + buttonPositions.Length];

			for (int i = 0; i < fieldPositions.Length; i++)
			{
				this.Buttons[i] = this.labelFactory.CreateButton(" ", fieldPositions[i], false, true);
			}

			for (int i = 0; i < buttonPositions.Length; i++)
			{
				this.Buttons[i + fieldPositions.Length] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
			}

			this.TextArea.Render();
		}

		private void InitializeTextArea()
		{
			Position consoleCenter = Position.ConsoleCenter();
			this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, consoleCenter.Top - 7);
		}

		public override IMenu ExecuteCommand()
		{
            if (this.CurrentOption.IsField)
            {
                string fieldInput = " " + this.reader.ReadLine(this.CurrentOption.Position.Left + 1, this.CurrentOption.Position.Top);

                this.Buttons[this.currentIndex] = this.labelFactory.CreateButton(fieldInput, this.CurrentOption.Position, this.CurrentOption.IsHidden, this.CurrentOption.IsField);

                return this;
            }

            try
            {
                string commandName = String.Join("", this.CurrentOption.Text.Split());
                ICommand command = this.commandFactory.CreateCommand(commandName);
                IMenu view = command.Execute(this.TitleInput, this.CategoryInput, this.TextArea.Text);

                return view;
            }
            catch
            {
                this.error = true;
                this.InitializeStaticLabels(Position.ConsoleCenter());
                return this;
            }
        }
	}
}
