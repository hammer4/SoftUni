using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] array = new bool[n + 1];
            array[0] = array[1] = false;
            for (int i = 2; i<=n; i++)
            {
                array[i] = true;
            }


            for(int i=0; i<=n; i++)
            {
                if(array[i] == true)
                {
                    Console.Write(i + " ");

                    int p = i;
                    int multiplier = 1;
                    while(p<= n)
                    {
                        array[p] = false;
                        multiplier++;
                        p = i * multiplier;
                    }
                }
            }
        }
    }
}
