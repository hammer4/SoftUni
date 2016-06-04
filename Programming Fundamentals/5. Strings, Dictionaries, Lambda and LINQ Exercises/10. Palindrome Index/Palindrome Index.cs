using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Palindrome_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder(str);
            bool isPalindrome = true;
            for(int i = 0; i<sb.Length/2; i++)
            {
                if(sb[i] != sb[sb.Length-i-1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if(isPalindrome)
            {
                Console.WriteLine(-1);
                return;
            }

            for(int i=0; i<sb.Length; i++)
            {
                char ch = sb[i];
                sb = sb.Remove(i, 1);

                isPalindrome = true;
                for (int j = 0; j < sb.Length / 2; j++)
                {
                    if (sb[j] != sb[sb.Length - j - 1])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if(isPalindrome)
                {
                    Console.WriteLine(i);
                    return;
                }

                sb.Insert(i, ch);
            }
        }
    }
}
