namespace Forum.App.Menus
{
	using Contracts;
	using Models;
    using System;

    public class MainMenu : Menu
    {
		private ISession session;
		private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;

		public MainMenu(ISession session, ILabelFactory labelFactory, ICommandFactory commandFactory)
        {
            this.session = session;
            this.commandFactory = commandFactory;
			this.labelFactory = labelFactory;

            this.Open();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[] { "Categories", "Log In", "Sign Up" };

            if (session?.IsLoggedIn ?? false)
            {
                buttonContents[1] = "Add Post";
                buttonContents[2] = "Log Out";
            }

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 2),
                new Position(consoleCenter.Left - 4, consoleCenter.Top + 6),
                new Position(consoleCenter.Left - 4, consoleCenter.Top + 8),
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
                this.Buttons[i] = labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
            }
        }

		protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[] 
            {
                "FORUM",
                string.Format("Hi, {0}", this.session?.Username),
            };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 6),
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 7),
            };

            this.Labels = new ILabel[labelContents.Length];

            int lastIndex = this.Labels.Length - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                this.Labels[i] = labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
            }

            this.Labels[lastIndex] = labelFactory
				.CreateLabel(labelContents[lastIndex], labelPositions[lastIndex], !session?.IsLoggedIn ?? true);
        }

		public override IMenu ExecuteCommand()
		{
            string commandName = String.Join("", this.CurrentOption.Text.Split()) + "Menu";

            ICommand command = commandFactory.CreateCommand(commandName);

            IMenu view = command.Execute();

            return view;
		}
    }
}
