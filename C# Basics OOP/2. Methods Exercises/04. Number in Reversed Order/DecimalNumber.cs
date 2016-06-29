using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Number_in_Reversed_Order
{
    public class DecimalNumber
    {
        public string value;

        public DecimalNumber(string value)
        {
            this.value = value;
        }

        public string NumberReversed()
        {
            char[] arr = this.value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
