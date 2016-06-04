using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Capitalization
{
    class Capitalization
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder(str);
            for(int i=0; i<sb.Length; i++)
            {
                if(i==0 || (i>0 && char.IsLower(sb[i]) && sb[i-1] == ' '))
                {
                    sb[i] = (char)(sb[i] - 32);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
