namespace Forum.App.Views
{
    using Forum.App.UserInterface.Contracts;

    internal class LogInView : IView
    {
        public LogInView(bool error, string userName, int passwordLength)
        {
            this.Error = error;
            InitializeLabels();
        }

        public ILabel[] Labels { get; private set; }

        public ILabel[] Buttons { get; private set; }

        public bool Error { get; }

        public string PasswordHolder { get; }

        protected void InitializeLabels()
        {
            Position consoleCenter = Position.ConsoleCenter();

            InitializeStaticLabels(consoleCenter);

            InitializeButtons(consoleCenter);
        }

        private void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[] { "Invalid username or password!", "Name:", "Password:" };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 13),   // Error: 
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 10),   // Name:
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 8),    // Password:
            };

            this.Labels = new ILabel[labelContents.Length];

            this.Labels[0] = new Label(labelContents[0], labelPositions[0], !this.Error);

            for (int i = 1; i < this.Labels.Length; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }

        private void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[]
            {
                " ", " ", "Log In", "Back"
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 10, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left - 6, consoleCenter.Top - 8),   // Password
                new Position(consoleCenter.Left + 16, consoleCenter.Top),      // Log In
                new Position(consoleCenter.Left + 16, consoleCenter.Top + 1)   // Back
            };

            this.Buttons = new ILabel[buttonContents.Length];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
                this.Buttons[i] = new Label(buttonContents[i], buttonPositions[i]);
            }
        }
    }
}
