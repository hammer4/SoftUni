namespace Forum.App.UserInterface.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
 
    public static class StringProcessor
    {
        private const int LINE_OFFSET = 37;
        public static IEnumerable<string> Split(string text)
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
                else if (i - lastSplit == LINE_OFFSET)
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
