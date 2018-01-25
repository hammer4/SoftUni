using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.__Poisonous_Plants
{
    class Program
    {
        public static void Main()
        {
            int plantsCount = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                        .Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)        // plant poison
                        .ToArray();
            var daysToDie = new int[plantsCount]; // day each plant dies (0 => plant never dies)
            var plantsLeftSeq = new Stack<int>(); // plants (indices) to the left of given plant
            plantsLeftSeq.Push(0);                // first plant pushed to the stack

            for (int i = 1; i < plantsCount; i++)
            {
                int maxDaysToDie = 0;
                // pop plants bigger than current plant & to the left of it
                while (plantsLeftSeq.Count != 0 && plants[plantsLeftSeq.Peek()] >= plants[i])
                {
                    maxDaysToDie = Math.Max(maxDaysToDie, daysToDie[plantsLeftSeq.Pop()]);
                }
                // empty plants stack => min plant [i] found (smaller than all plants to the left of it)
                // min plants never die => daysToDie = 0
                if (plantsLeftSeq.Count != 0)
                {
                    daysToDie[i] = maxDaysToDie + 1;
                }
                plantsLeftSeq.Push(i);
            }
            Console.WriteLine(daysToDie.Max());
        }
    }
}
