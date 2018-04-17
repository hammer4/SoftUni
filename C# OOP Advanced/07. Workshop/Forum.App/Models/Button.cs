namespace Forum.App.Models
{
	using Contracts;

	public class Button : IButton
	{
		public Button(string text, Position position, bool isHidden = false, bool isField = false)
		{
			this.Text = text;
			this.Position = position;
			this.IsHidden = isHidden;
			this.IsField = isField;
		}

		public string Text { get; }

		public bool IsHidden { get; }

		public bool IsField { get; }

		public Position Position { get; }
	}
}
