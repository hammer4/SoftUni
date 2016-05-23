using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.English_Name_оf_The
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine(LastDigit(number));

        }

        static string LastDigit(string num)
        {
            int lastDigit = num[num.Length - 1];
            string digit = string.Empty;

            switch(lastDigit)
            {
                case '0': digit = "zero"; break;
                case '1': digit = "one"; break;
                case '2': digit = "two"; break;
                case '3': digit = "three"; break;
                case '4': digit = "four"; break;
                case '5': digit = "five"; break;
                case '6': digit = "six"; break;
                case '7': digit = "seven"; break;
                case '8': digit = "eight"; break;
                case '9': digit = "nine"; break;
                default: digit = "error"; break;
            }

            return digit;
        }
    }
}
