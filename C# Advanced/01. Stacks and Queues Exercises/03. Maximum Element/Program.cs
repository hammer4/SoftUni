using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            Stack<int> maxStack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            int maxEl = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();

                switch (query[0])
                {
                    case 1:
                        {
                            if (maxEl < query[1])
                            {
                                maxEl = query[1];
                                maxStack.Push(maxEl);
                            }

                            stack.Push(query[1]);
                        }
                        break;
                    case 2:
                        {
                            if (stack.Peek() == maxStack.Peek() && maxStack.Count > 0)
                            {
                                maxStack.Pop();
                                if (maxStack.Count > 0)
                                {
                                    maxEl = maxStack.Peek();
                                }
                                else
                                {
                                    maxEl = int.MinValue;
                                }
                            }

                            stack.Pop();

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine(maxStack.Peek());
                        }
                        break;
                }
            }
        }
    }
}
