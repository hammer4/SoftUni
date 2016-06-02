using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Max_Sequence_of_Equal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int currentSeqStartIndex = 0;
            int currentSeqLength = 1;
            int longestSeqStartIndex = 0;
            int longestSeqLength = 1;

            for(int i = 0; i<list.Count - 1; i++)
            {
                if (list[i] == list[i+1])
                {
                    currentSeqLength++;
                    if(currentSeqLength > longestSeqLength)
                    {
                        longestSeqLength = currentSeqLength;
                        longestSeqStartIndex = currentSeqStartIndex;
                    }
                }
                else
                {
                    currentSeqStartIndex = i + 1;
                    currentSeqLength = 1;
                }
            }

            List<int> result = list.Skip(longestSeqStartIndex).Take(longestSeqLength).ToList();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
