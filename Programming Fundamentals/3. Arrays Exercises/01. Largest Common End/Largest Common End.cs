using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ');
            string[] array2 = Console.ReadLine().Split(' ');
            int minLength = Math.Min(array1.Length, array2.Length);
            int diff = Math.Abs(array1.Length - array2.Length);
            int leftSeqLen = 0;

            for (int i=0; i<minLength; i++)
            {
                if(array1[i] != array2[i])
                {
                    break;
                }

                leftSeqLen++;
            }

            array1 = array1.Reverse().ToArray();
            array2 = array2.Reverse().ToArray();
            int rightSeqLen = 0;
            for (int i = 0; i < minLength; i++)
            {
                if (array1[i] != array2[i])
                {
                    break;
                }

                rightSeqLen++;
            }

            Console.WriteLine(Math.Max(leftSeqLen, rightSeqLen));
        }
    }
}
