using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Largest_Increasing_Sub
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> longestIncreasingSeq = new List<int>();

            for (int mask = 1; mask < Math.Pow(2, list.Count); mask++)
            {
                List<int> combination = new List<int>();
                for (int i = 0; i < list.Count; i++)
                {
                    if ((mask >> i & 1) == 1)
                    {
                        combination.Add(list[i]);
                    }
                }
                bool isIncreasing = true;
                for(int i=0; i<combination.Count - 1; i++)
                {
                    if(combination[i] >= combination[i+1])
                    {
                        isIncreasing = false;
                        break;
                    }
                }

                if(isIncreasing && combination.Count> longestIncreasingSeq.Count)
                {
                    longestIncreasingSeq = combination;
                }
            }

            Console.WriteLine(string.Join(" ", longestIncreasingSeq));
        }
    }
}
