using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25.Master_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            for(int i=1; i<= end; i++)
            {
                if(IsPalindrome(i) && SumOfDigits(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        static bool IsPalindrome(int num)
        {
            bool isPalindrome = true;
            string number = num.ToString();
            for (int i =0; i<number.Length; i++)
            {
                if(number[i] != number[number.Length - i - 1])
                {
                    isPalindrome = false;
                }
            }

            return isPalindrome;
        }

        static bool SumOfDigits(int num)
        {
            int sum = 0;
            while(num>0)
            {
                int digit = num % 10;
                sum += digit;
                num /= 10;
            }

            if(sum % 7 == 0)
            {
                return true;
            }

            return false;
        }

        static bool ContainsEvenDigit (int num)
        {
            while(num > 0)
            {
                byte digit = (byte)(num % 10);
                if(digit % 2 == 0)
                {
                    return true;
                }

                num /= 10;
            }

            return false;
        }
    }
}
