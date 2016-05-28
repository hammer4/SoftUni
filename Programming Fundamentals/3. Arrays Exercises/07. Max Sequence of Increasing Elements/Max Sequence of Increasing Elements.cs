using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int longestSeqLength = 1;
            int longestSeqStart = 0;
            int currentSeqLength = 1;
            int currentSeqStart = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[i - 1])
                {
                    currentSeqLength++;

                    if (currentSeqLength > longestSeqLength)
                    {
                        longestSeqLength = currentSeqLength;
                        longestSeqStart = currentSeqStart;
                    }
                }
                else
                {
                    currentSeqLength = 1;
                    currentSeqStart = i;
                }
            }

            for (int i = longestSeqStart; i < longestSeqStart + longestSeqLength; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
