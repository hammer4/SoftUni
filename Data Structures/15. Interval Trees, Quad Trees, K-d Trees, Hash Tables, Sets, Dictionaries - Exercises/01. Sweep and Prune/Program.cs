using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static List<GameObject> objects;
    private static int counter = 0;

    static void Main(string[] args)
    {
        objects = new List<GameObject>();

        string command;

        while((command = Console.ReadLine()) != "start")
        {
            var tokens = command.Split();

            switch (tokens[0])
            {
                case "add":
                    Add(tokens);
                    break;
            }
        }

        while((command = Console.ReadLine()) != "end")
        {
            var tokens = command.Split();

            switch (tokens[0])
            {
                case "tick":
                    counter++;
                    SweepAndPrune();
                    break;
                case "move":
                    counter++;
                    objects.Single(o => o.Name == tokens[1]).Move(double.Parse(tokens[2]), double.Parse(tokens[3]));
                    SweepAndPrune();
                    break;
            }
        }
    }

    private static void Add(string[] tokens)
    {
        objects.Add(new GameObject(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3])));
    }

    private static void SweepAndPrune()
    {
        InsertionSort();

        for(int i=0; i<objects.Count; i++)
        {
            var currentObject = objects[i];

            for(int j=i+1; j<objects.Count; j++)
            {
                var candidateCollisionObj = objects[j];

                if(currentObject.X2 < candidateCollisionObj.X1)
                {
                    break;
                }

                if(currentObject.Y1 <= candidateCollisionObj.Y2 && currentObject.Y2 >= candidateCollisionObj.Y1)
                {
                    Console.WriteLine($"({counter}) {currentObject.Name} collides with {candidateCollisionObj.Name}");
                }
            }
        }
    }

    static void InsertionSort()
    {
        int i = 1;

        while(i < objects.Count)
        {
            int j = i;

            while(j > 0 && objects[j-1]?.X1 > objects[j]?.X1)
            {
                GameObject temp = objects[j - 1];
                objects[j - 1] = objects[j];
                objects[j] = temp;
                j--;
            }
            i++;
        }
    }
}