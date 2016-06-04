using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Common_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            for(int i=0; i<str1.Length; i++)
            {
                string substr1 = str1.Substring(i, 1);

                for(int j=0; j<str2.Length; j++)
                {
                    string substr2 = str2.Substring(j, 1);

                    if(substr1 == substr2)
                    {
                        Console.WriteLine("yes");
                        return;
                    }
                }
            }

            Console.WriteLine("no");
        }
    }
}
