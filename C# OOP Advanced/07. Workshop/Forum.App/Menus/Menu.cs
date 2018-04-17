namespace Forum.App.Menus
{
	using Models;
	using Contracts;

	public abstract class Menu : IMenu
	{
		protected int currentIndex;

		public Menu()
		{
			this.currentIndex = 0;
		}

		public ILabel[] Labels { get; protected set; }

		public IButton[] Buttons { get; protected set; }

		public IButton CurrentOption => this.Buttons[currentIndex];

		public abstract IMenu ExecuteCommand();

		public virtual void Open()
		{
			Position consoleCenter = Position.ConsoleCenter();

			this.InitializeStaticLabels(consoleCenter);

			this.InitializeButtons(consoleCenter);
		}

		protected abstract void InitializeStaticLabels(Position consoleCenter);

		protected abstract void InitializeButtons(Position consoleCenter);

		public void NextOption()
		{
			this.currentIndex++;

			int totalOptions = this.Buttons.Length;

			if (this.currentIndex >= totalOptions)
			{
				this.currentIndex -= totalOptions;
			}

			if (this.CurrentOption.IsHidden)
			{
				this.NextOption();
			}
		}

		public void PreviousOption()
		{
			this.currentIndex--;

			if (this.currentIndex < 0)
			{
				this.currentIndex += this.Buttons.Length;
			}

			if (this.CurrentOption.IsHidden)
			{
				this.PreviousOption();
			}
		}
	}
}
