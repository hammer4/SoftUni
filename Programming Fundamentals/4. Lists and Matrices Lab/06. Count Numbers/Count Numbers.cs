using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            numbers.Sort();
            List<int> passed = new List<int>();

            for(int i=0; i<numbers.Count; i++)
            {
                if(!passed.Contains(numbers[i]))
                {
                    int counter = 0;

                    for(int j=i; j<numbers.Count; j++)
                    {
                        if(numbers[j] == numbers[i])
                        {
                            counter++;
                        }
                    }

                    Console.WriteLine("{0} -> {1}", numbers[i], counter);
                    passed.Add(numbers[i]);
                }
            }
        }
    }
}
