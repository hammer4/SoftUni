namespace Forum.App.Factories
{
	using Models;
	using Contracts;

	public class LabelFactory : ILabelFactory
	{
		public ILabel CreateLabel(string contents, Position position, bool isHidden = false)
		{
			return new Label(contents, position, isHidden);
		}

		public IButton CreateButton(string contents, Position position, bool isHidden = false, bool isField = false)
		{
			return new Button(contents, position, isHidden, isField);
		}
	}
}
