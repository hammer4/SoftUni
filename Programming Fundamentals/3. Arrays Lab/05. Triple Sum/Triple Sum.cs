using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = 0;
            for(int i=0; i<array.Length; i++)
            {
                for(int j=i+1; j<array.Length; j++)
                {
                    int sum = array[i] + array[j];
                    if(array.Contains(sum))
                    {
                        Console.WriteLine("{0} + {1} == {2}", array[i], array[j], sum);
                        counter++;
                    }
                }
            }

            if(counter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
