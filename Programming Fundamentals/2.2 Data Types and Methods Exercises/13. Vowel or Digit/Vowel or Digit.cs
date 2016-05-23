using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch = char.Parse(Console.ReadLine());

            if(ch == 65 || ch == 69 || ch == 73 || ch == 79 || ch == 85 || ch == 89 || ch == 97 || ch == 101 || ch == 105 || ch == 111 || ch == 117 || ch == 121 || ch == 129)
            {
                Console.WriteLine("vowel");
            }
            else if (ch >= 48 && ch <= 57)
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
