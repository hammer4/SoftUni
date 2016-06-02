using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Count_Letters_in
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int[] counts = new int[str.Max() + 1];
            foreach(char ch in str)
            {
                if(ch >= 65 && ch <= 90)
                {
                    counts[ch + 32]++;
                }
                else
                {
                    counts[ch]++;
                }
            }

            for(int i=0; i<counts.Length; i++)
            {
                if(counts[i] > 0)
                {
                    Console.WriteLine((char)i + " -> " + counts[i]);
                }
            }
        }
    }
}
