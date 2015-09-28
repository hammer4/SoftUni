using System;
using System.Collections.Generic;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        List<List<int>> allLists = new List<List<int>>(rows*2);
        
        for(int i=0; i<rows*2; i++)
        {
            allLists.Add(Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList<int>());
        }

        for(int i = rows; i<allLists.Count(); i++)
        {
            allLists[i].Reverse();
        }

        int columns = allLists[0].Count() + allLists[rows].Count();
        bool isRectangularMatrix = true;
        for(int i=1; i<rows; i++)
        {
            if (allLists[i].Count() + allLists[i+rows].Count() != columns)
            {
                isRectangularMatrix = false;
            }
        }

        if(isRectangularMatrix)
        {
            for(int i=0; i<rows; i++)
            {
                allLists[i].AddRange(allLists[i+rows]);
                Console.Write("[");
                for(int j=0; j<allLists[i].Count -1; j++)
                {
                    Console.Write(allLists[i][j] + ", ");
                }
                Console.WriteLine(allLists[i][allLists[i].Count - 1] + "]");
            }
        }
        else
        {
            int totalCount = 0;
            foreach(List<int> list in allLists)
            {
                foreach(int integer in list)
                {
                    totalCount++;
                }
            }
            Console.WriteLine("The total number of cells is: " + totalCount);
        }
    }
}
