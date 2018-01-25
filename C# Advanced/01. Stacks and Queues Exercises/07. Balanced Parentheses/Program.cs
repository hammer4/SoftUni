using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            bool isBalanced = true;

            foreach(var ch in input)
            {
                switch (ch)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(ch);
                        break;
                    case ')':
                        if(!stack.Any() || stack.Pop() != '(')
                        {
                            isBalanced = false;
                        }
                        break;
                    case '}':
                        if (!stack.Any() || stack.Pop() != '{')
                        {
                            isBalanced = false;
                        }
                        break;
                    case ']':
                        if (!stack.Any() || stack.Pop() != '[')
                        {
                            isBalanced = false;
                        }
                        break;
                }
            }

            var result = isBalanced ? "YES" : "NO";
            Console.WriteLine(result);
        }
    }
}
