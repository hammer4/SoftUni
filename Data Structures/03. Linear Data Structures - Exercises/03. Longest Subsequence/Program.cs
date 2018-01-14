using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();

        int longestSequenceCount = 1;
        int longestSequenceStartIndex = 0;
        int currentSequenceCount = 1;
        int currentSequenceStartIndex = 0;

        for(int i = 1; i < list.Count; i++)
        {
            if(list[i] == list[i - 1])
            {
                currentSequenceCount++;

                if(currentSequenceCount > longestSequenceCount)
                {
                    longestSequenceCount = currentSequenceCount;
                    longestSequenceStartIndex = currentSequenceStartIndex;
                }
            }
            else
            {
                currentSequenceCount = 1;
                currentSequenceStartIndex = i;
            }
        }

        Console.WriteLine(String.Join(" ", list.Skip(longestSequenceStartIndex).Take(longestSequenceCount)));
    }
}
