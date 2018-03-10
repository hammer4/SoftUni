namespace Forum.App
{
    using Forum.App.UserInterface.Contracts;

    internal class Label : ILabel
    {
        public Label(string text, Position position, bool isHidden = false)
        {
            this.Text = text;
            this.Position = position;
            this.IsHidden = isHidden;
        }

        public string Text { get; private set; }
        public bool IsHidden { get; private set; }
        public Position Position { get; private set; }
    }
}
