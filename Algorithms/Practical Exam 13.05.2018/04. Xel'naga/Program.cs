using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Xelnaga
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Dictionary<int, int> counts = new Dictionary<int, int>();
            int count = 0;
            int index = 0;
            while (nums[index] != -1)
            {
                int num = nums[index];
                if (!counts.ContainsKey(num))
                {
                    counts.Add(num, num);
                    count += num + 1;
                }
                else
                {
                    if (counts[nums[index]] == 0)
                    {
                        counts[num] += num;
                        count += num + 1;
                    }
                    else
                    {
                        counts[num]--;
                    }
                }
                index++;
            }
            Console.WriteLine(count);
        }
    }
}