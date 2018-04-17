using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.ViewModels
{
    public class ContentViewModel
    {
        private const int lineHeight = 37;

        public ContentViewModel(string content)
        {
            this.Content = this.GetLines(content);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            ICollection<string> lines = new List<string>();

            for(int i=0; i<content.Length; i+= lineHeight)
            {
                char[] row = contentChars.Skip(i).Take(lineHeight).ToArray();
                string rowString = String.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}
