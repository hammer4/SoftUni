namespace Forum.App.Views
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.UserInterface.Contracts;

    class CategoriesView : IView
    {
        public CategoriesView(string[] categoryNames, bool isFirstPage = false, bool isLastPage = false)
        {
            this.IsFirstPage = isFirstPage;
            this.IsLastPage = isLastPage;
            this.CategoryNames = categoryNames;
            InitializeLabels();
        }

        public bool IsFirstPage { get; }
        public bool IsLastPage { get; }
        public string[] CategoryNames { get; }

        public ILabel[] Labels { get; private set; }
        public ILabel[] Buttons { get; set; }

        private void InitializeLabels()
        {
            Position consoleCenter = Position.ConsoleCenter();

            InitializeStaticLabels(consoleCenter);

            InitializeButtons(consoleCenter);
        }

        private void InitializeButtons(Position consoleCenter)
        {
            string[] defaultButtonContent = new string[] { "Back", "Previous Page", "Next Page" };
            Position[] defaultButtonPositions = new Position[]
            {
                new Position(consoleCenter.Left + 15, consoleCenter.Top - 12), // Back   
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 12), // Previous Page
                new Position(consoleCenter.Left + 10, consoleCenter.Top + 12), // Next Page
            };

            Position[] categoryButtonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 8),
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 6),
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 4),
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 2),
                new Position(consoleCenter.Left - 18, consoleCenter.Top),
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 2),
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 4),
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 6),
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 8),
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 10),
            };

            IList<ILabel> buttons = new List<ILabel>();
            buttons.Add(new Label(defaultButtonContent[0], defaultButtonPositions[0]));

            for (int i = 0; i < categoryButtonPositions.Length; i++)
            {
                string currentCategoryName = string.Empty;

                if (i < this.CategoryNames.Length)
                {
                    currentCategoryName = this.CategoryNames[i];
                }

                ILabel label = new Label(currentCategoryName, categoryButtonPositions[i], currentCategoryName == string.Empty);

                buttons.Add(label);
            }

            buttons.Add(new Label(defaultButtonContent[1], defaultButtonPositions[1], this.IsFirstPage));
            buttons.Add(new Label(defaultButtonContent[2], defaultButtonPositions[2], this.IsLastPage));

            this.Buttons = buttons.ToArray();
        }

        private void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContent = new string[] { "CATEGORIES", "Name", /*"Posts"*/ };
            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // CATEGORIES
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Name
                //new Position(consoleCenter.Left + 14, consoleCenter.Top - 10), // Posts
            };

            IList<ILabel> labels = new List<ILabel>();

            for (int i = 0; i < labelContent.Length; i++)
            {
                labels.Add(new Label(labelContent[i], labelPositions[i]));
            }

            this.Labels = labels.ToArray();
        }
    }
}
