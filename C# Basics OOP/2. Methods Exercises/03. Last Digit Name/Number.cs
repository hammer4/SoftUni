using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Last_Digit_Name
{
    public class Number
    {
        public int value;

        public Number(int value)
        {
            this.value = value;
        }

        public string LastDigitName()
        {
            int digit = this.value % 10;
            switch(digit)
            {
                case 0: return "zero";
                case 1: return "one"; 
                case 2: return "two"; 
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six"; 
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "error"; break;
            }
        }
    }
}
