using System;
using System.Collections.Generic;

class JoinLists
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        List<int> list1 = new List<int>();
        foreach(string number in numbers)
        {
            list1.Add(int.Parse(number));
        }
        
        input = Console.ReadLine();
        numbers = input.Split(' ');
        List<int> list2 = new List<int>();
        foreach (string number in numbers)
        {
            list2.Add(int.Parse(number));
        }

        List<int> list3 = new List<int>();
        foreach(int integer in list1)
        {
            if(!list3.Contains(integer))
            {
                list3.Add(integer);
            }
        }

        foreach (int integer in list2)
        {
            if (!list3.Contains(integer))
            {
                list3.Add(integer);
            }
        }

        list3.Sort();
        Console.WriteLine(String.Join(" ", list3));
    }
}
