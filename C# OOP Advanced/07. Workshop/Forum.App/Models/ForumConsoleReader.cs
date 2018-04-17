namespace Forum.App.Models
{
	using System;

	using Contracts;

	public class ForumConsoleReader : IForumReader
	{
		private bool CursorVisible { get => Console.CursorVisible; set => Console.CursorVisible = value; }

		public string ReadLine()
		{
			int cursorLeft = Console.CursorLeft;
			int cursorTop = Console.CursorTop;

			return this.ReadLine(cursorLeft, cursorTop);
		}

		public string ReadLine(int cursorLeft, int cursorTop)
		{
			ClearRow(cursorLeft, cursorTop);

			ShowCursor();
			string result = Console.ReadLine();
			HideCursor();
			return result;
		}

		public void HideCursor()
		{
			CursorVisible = false;
		}

		public void ShowCursor()
		{
			CursorVisible = true;
		}

		private void ClearRow(int left, int top)
		{
			Console.SetCursorPosition(left, top);
			Console.Write(new string(' ', 60 - left));

			Console.SetCursorPosition(left, top);
		}
	}
}
