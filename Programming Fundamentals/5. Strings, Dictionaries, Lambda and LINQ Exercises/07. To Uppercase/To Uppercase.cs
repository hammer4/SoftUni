using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.To_Uppercase
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int start = text.IndexOf("<upcase>");
            int end = text.IndexOf("</upcase>") + 9;

            while(start != -1 && end != -1)
            {
                StringBuilder sb = new StringBuilder(text);
                for(int i= start; i<end; i++)
                {
                    if(sb[i] >= 'a' && sb[i]<='z')
                    {
                        sb[i] -= (char)32;
                    }
                }

                sb = sb.Remove(end - 9, 9);
                sb = sb.Remove(start, 8);
                text = sb.ToString();
                start = text.IndexOf("<upcase>");
                end = text.IndexOf("</upcase>") + 9;
            }

            Console.WriteLine(text);
        }
    }
}
