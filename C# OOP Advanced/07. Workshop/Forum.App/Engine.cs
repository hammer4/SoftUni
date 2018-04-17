namespace Forum.App
{
	using System;

	using Contracts;

    public class Engine
    {
        private IMainController menu;

        public Engine(IMainController menuController)
        {
			this.menu = menuController;
        }

        internal void Run()
        {
            while (true)
            {
                menu.MarkOption();

                var keyInfo = Console.ReadKey(true);
                var key = keyInfo.Key;

				menu.UnmarkOption();

                switch (key)
                {
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Escape:
                        menu.Back();
                        break;
                    case ConsoleKey.Home:
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        menu.PreviousOption();
                        break;
                    case ConsoleKey.Tab:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        menu.NextOption();
                        break;
                    case ConsoleKey.Enter:
                        menu.Execute();
                        break;
                }
            }
        }
	}
}
