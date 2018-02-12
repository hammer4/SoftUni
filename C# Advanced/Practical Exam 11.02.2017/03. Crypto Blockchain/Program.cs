using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            string result = String.Empty;

            int count = int.Parse(Console.ReadLine());

            string pattern = @"\[[^\[\]{}]*?([0-9]{3,})[^\[\]{}]*?\]|{[^{}\]\[]*?([0-9]{3,})[^{}\]\[]*?}";

            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();
                input = String.Concat(input, line);
            }

            var matches = Regex.Matches(input, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                int groupNumber = matches[i].Groups[1].ToString() == String.Empty ? 2 : 1;

                var numbersLength = matches[i].Groups[groupNumber].ToString().Length;
                if (numbersLength % 3 == 0)
                {
                    int totalLength = matches[i].Groups[0].ToString().Length;
                    for (int j = 0; j < numbersLength / 3; j++)
                    {
                        var temp = matches[i].Groups[groupNumber].ToString()
                            .Skip(3 * j).Take(3);

                        string charCode = String.Concat(temp);
                        int currentCode = int.Parse(charCode);

                        currentCode -= totalLength;

                        result = String.Concat(result, (char)currentCode);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
