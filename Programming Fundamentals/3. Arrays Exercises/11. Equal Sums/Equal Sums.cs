using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for(int i =0; i<array.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for(int j=0; j<i; j++)
                {
                    leftSum += array[j];
                }

                for(int j=i+1; j<array.Length; j++)
                {
                    rightSum += array[j];
                }

                if(leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
