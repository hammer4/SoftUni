namespace Forum.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
	using System.Threading;
	using Contracts;

    public class TextInputArea : ITextInputArea
    {
		private const int lineLength = 37;

		private const int postMaxLength = 660;
		private const int postAreaHeight = 18;

		private const int replyMaxLength = 220;
		private const int replyAreaHeight = 6;

		private int x;
        private int y;
        private int height;
		private int maxLength;

        private int textCursorPosition;
        private Position displayCursor;
		private IForumReader reader;

        private IEnumerable<string> lines = new List<string>();
        private string text = string.Empty;
        private static char[] forbiddenCharacters = { ';' };

		public TextInputArea(IForumReader reader, int x, int y, bool isPost = true)
		{
			this.reader = reader;

			this.x = x;
			this.y = y;
			this.displayCursor = new Position(x, y);

			this.height = isPost ? postAreaHeight : replyAreaHeight;
			this.maxLength = isPost ? postMaxLength : replyMaxLength;
		}

        public int Left { get => this.x; }

        public int Top { get => this.y; }

        public IEnumerable<string> Lines
        {
            get => this.lines;
        }

        public string Text
        {
            get => this.text;
            set
            {
                this.text = value;
                this.lines = this.Split(value);
            }
        }

        public Position DisplayCursor
        {
            get => this.displayCursor;
        }

        public void Write()
        {
			this.Render();
            this.reader.ShowCursor();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.Backspace)
                {
                    this.Delete();
                }
                else if (this.Text.Length == this.maxLength || forbiddenCharacters.Contains(keyInfo.KeyChar))
                {
					new Thread(() => Console.Beep(415, 260)).Start();
                    continue;
                }
                else if (key == ConsoleKey.Enter || key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    this.AddCharacter(keyInfo.KeyChar);
                }
            }

            this.reader.HideCursor();
        }

		public void Render()
		{
			int top = this.Top;

			Console.SetCursorPosition(this.Left, top);

			foreach (var item in this.Lines)
			{
				Console.SetCursorPosition(this.Left, top);
				Console.Write(new string(' ', 37));
				Console.SetCursorPosition(this.Left, top);
				foreach (var ch in item)
				{
					Console.Write(ch);
				}
				top++;
			}
		}

		private bool AddCharacter(char character)
		{
			if (this.Text.Length < this.maxLength)
			{
				string stringBefore = this.Text.Substring(0, textCursorPosition);
				string stringAfter = this.Text.Substring(textCursorPosition, this.Text.Length - textCursorPosition);

				this.Text = stringBefore + character + stringAfter;

				this.textCursorPosition++;
				this.Render();
				return true;
			}
			return false;
		}

		public void Delete()
        {
            if (this.textCursorPosition > 0)
            {
                string stringBefore = this.Text.Substring(0, textCursorPosition);
                string stringAfter = this.Text.Substring(textCursorPosition, this.Text.Length - textCursorPosition);

                stringBefore = stringBefore.Substring(0, stringBefore.Length - 1);
                this.Text = stringBefore + stringAfter;
                this.textCursorPosition--;
				this.Render();
            }
            this.lines = this.Split(this.Text);
        }

		private IEnumerable<string> Split(string text)
		{
			List<String> splitText = new List<String>();

			var lastSplit = 0;
			for (var i = 0; i < text.Length + 1; i++)
			{
				if (text.Length > i && text[i] == '\n')
				{
					splitText.Add(text.Substring(lastSplit, i - lastSplit + 1));
					lastSplit = i + 1;
				}
				else if (i - lastSplit == lineLength)
				{
					splitText.Add(text.Substring(lastSplit, i - lastSplit));
					lastSplit = i;
				}

				if (i == text.Length)
					splitText.Add(text.Substring(lastSplit, text.Length - lastSplit));
			}

			return splitText.Select(x => x.Replace('\r', ' '));
		}
	}
}
