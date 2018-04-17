namespace Forum.App.Models
{
    using Forum.App.Contracts;

    internal class Label : ILabel
    {
        public Label(string text, Position position, bool isHidden = false)
        {
            this.Text = text;
            this.Position = position;
            this.IsHidden = isHidden;
        }

        public string Text { get; }

        public bool IsHidden { get; }

        public Position Position { get; }
    }
}
