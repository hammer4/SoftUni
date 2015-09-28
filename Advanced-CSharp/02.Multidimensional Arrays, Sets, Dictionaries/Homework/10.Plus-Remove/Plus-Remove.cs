using System;
using System.Collections.Generic;

class PlusRemove
{
    static void Main()
    {
        int counter = -1;
        List<List<string>> list = new List<List<string>>();
        List<List<string>> resultList = new List<List<string>>();
        string input = Console.ReadLine();

        while (input != "END")
        {
            counter++;
            list.Add(new List<string>());

            for (int i = 0; i < input.Length; i++)
            {
                list[counter].Add(input.Substring(i, 1));
            }

            input = Console.ReadLine();
        }

        for (int i = 0; i < list.Count; i++) //copy list
        {
            resultList.Add(new List<string>());
            for (int j = 0; j < list[i].Count; j++)
            {
                resultList[i].Add(list[i][j]);
            }
        }

        if (list.Count < 3)
        {
            foreach (List<string> list1 in list)
            {
                foreach (string str in list1)
                {
                    Console.Write(str);
                }
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (list[i].Count < 3 || list[i - 1].Count < 2 || list[i + 1].Count < 2)
                {
                    continue;
                }

                int min = Math.Min(list[i].Count, list[i - 1].Count);
                min = Math.Min(min, list[i + 1].Count);

                for (int j = 1; j < min; j++)
                {
                    if (list[i].Count == min && j == min - 1)
                    {
                        continue;
                    }
                    if (list[i][j].ToLower() == list[i][j - 1].ToLower() && list[i][j].ToLower() == list[i][j + 1].ToLower() && list[i][j].ToLower() == list[i - 1][j].ToLower() && list[i][j].ToLower() == list[i + 1][j].ToLower())
                    {
                        resultList[i][j] = string.Empty;
                        resultList[i][j - 1] = string.Empty;
                        resultList[i][j + 1] = string.Empty;
                        resultList[i - 1][j] = string.Empty;
                        resultList[i + 1][j] = string.Empty;
                    }
                }
            }
        }

        foreach(List<string> list1 in resultList)
        {
            foreach(string str in list1)
            {
                Console.Write(str);
            }
            Console.WriteLine();
        }
    }
}