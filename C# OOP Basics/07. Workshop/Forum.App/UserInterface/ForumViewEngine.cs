namespace Forum.App.UserInterface
{
	using Forum.App.UserInterface.Contracts;
	using Forum.App.UserInterface.Input;
	using System;
	using System.Linq;

	internal class ForumViewEngine
	{
		private ConsoleColor backgroundColor;
		private ConsoleColor highlightColor;

		public ForumViewEngine()
		{
			this.InitializeConsole();
		}

		#region HardCoded Console
		private ConsoleColor hardCodedBgColor = ConsoleColor.Blue;
		private ConsoleColor hardCodedHlColor = ConsoleColor.DarkMagenta;
		private ConsoleColor hardCodedFontColor = ConsoleColor.White;

		internal static void ResetBuffer()
		{
			Clear();
			Console.BufferHeight = 30;
		}

		private void InitializeConsole()
		{
			this.BackgroundColor = hardCodedBgColor;
			this.HighlightColor = hardCodedHlColor;

			Console.BackgroundColor = this.BackgroundColor;
			Console.ForegroundColor = hardCodedFontColor;

			Console.CursorVisible = false;
			Console.SetWindowSize(60, 30);
			Console.BufferHeight = Console.WindowHeight;
			Console.BufferWidth = Console.WindowWidth;

			Clear();
		}
		#endregion

		#region Default Dynamic Console
		//private const int HIGHLIGHT_OFFSET = 2;
		//private const int POST_ROW_LENGTH = 37;

		//private void InitializeConsole()
		//{
		//    this.BackgroundColor = Console.BackgroundColor;
		//    this.HighlightColor = this.BackgroundColor + HIGHLIGHT_OFFSET;
		//    Console.CursorVisible = false;
		//    Console.SetWindowSize(60, 30);
		//    Console.BufferHeight = Console.WindowHeight;
		//    Console.BufferWidth = Console.WindowWidth;
		//}
		#endregion

		internal static void SetCursorPosition(int left, int top)
		{
			Console.SetCursorPosition(left, top);
		}

		internal void RenderView(IView view)
		{
			Clear();

			foreach (var label in view.Labels.Where(l => !l.IsHidden))
			{
				this.DisplayLabel(label);
			}

			foreach (var button in view.Buttons.Where(b => !b.IsHidden))
			{
				this.DisplayLabel(button);
			}
		}

		private ConsoleColor BackgroundColor
		{
			get
			{
				return this.backgroundColor;
			}
			set
			{
				this.backgroundColor = value;
			}
		}

		private ConsoleColor HighlightColor
		{
			get
			{
				return this.highlightColor;
			}
			set
			{
				ConsoleColor maxColor = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().Last();

				if (value > maxColor)
				{
					value = (ConsoleColor)((int)value % (int)maxColor);
				}

				this.highlightColor = value;
			}
		}

		public static bool CursorVisible { get => Console.CursorVisible; set => Console.CursorVisible = value; }

		private void DisplayLabel(ILabel label)
		{
			SetCursorPosition(label.Position.Left, label.Position.Top);
			Console.WriteLine(label.Text);
		}

		public void Mark(ILabel label, bool highlighted = true)
		{
			SetCursorPosition(label.Position.Left, label.Position.Top);

			//Highlight Option
			if (highlighted)
			{
				Console.BackgroundColor = this.HighlightColor;
			}

			Console.Write(label.Text);

			//Reset background color to prevent using 
			//the wrong background color for other actions
			Console.BackgroundColor = this.BackgroundColor;
		}

		public static void Clear()
		{
			Console.Clear();
			Console.CursorVisible = false;
		}

		internal static void HideCursor()
		{
			CursorVisible = false;
		}

		internal static void ShowCursor()
		{
			CursorVisible = true;
		}

		internal static void SetBufferHeight(int rows)
		{
			Console.BufferHeight = rows;
		}

		internal static string ReadRow()
		{
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            ClearRow(cursorLeft, cursorTop);

			ShowCursor();
			string result = Console.ReadLine();
			HideCursor();
			return result;
		}

		internal static void ClearRow(int left, int top)
		{
			Console.SetCursorPosition(left, top);
			Console.Write(new string(' ', 30));

            Console.SetCursorPosition(left, top);
		}

		internal static void WriteLine(string text)
		{
			Console.WriteLine(text);
		}

		public static void DrawTextArea(TextArea textArea)
		{
			int left = textArea.Left;
			int top = textArea.Top;

            Console.SetCursorPosition(left, top);

            foreach (var item in textArea.Lines)
			{
				Console.SetCursorPosition(left, top);
				Console.Write(new string(' ', 37));
				Console.SetCursorPosition(left, top);
				foreach (var ch in item)
				{
					Console.Write(ch);
				}
				top++;
			}
		}
	}
}
