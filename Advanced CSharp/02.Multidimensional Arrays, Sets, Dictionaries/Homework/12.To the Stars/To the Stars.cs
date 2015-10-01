using System;
using System.Collections.Generic;

class TotheStars
{
    static void Main()
    {
        Dictionary<string, List<double>> stars = new Dictionary<string, List<double>>();
        double[] shipCoordinates = new double[2];
        string[] input;

        for(int i=1; i<=3; i++)
        {
            input = Console.ReadLine().Split(new char[0]);
            List<double> list = new List<double>();
            list.Add(double.Parse(input[1]));
            list.Add(double.Parse(input[2]));
            string starName = input[0].ToLower();
            stars.Add(starName, list);
        }

        input = Console.ReadLine().Split(new char[0]);
        shipCoordinates[0] = double.Parse(input[0]);
        shipCoordinates[1] = double.Parse(input[1]);

        int numberOfTurns = int.Parse(Console.ReadLine());

        for(int i=0; i<= numberOfTurns; i++)
        {
            int counter = 0;

            foreach(KeyValuePair<string, List<double>> keyValue in stars)
            {
                if(shipCoordinates[0] >= keyValue.Value[0]-1 && shipCoordinates[0] <= keyValue.Value[0] +1 && shipCoordinates[1] >= keyValue.Value[1]-1 && shipCoordinates[1] <= keyValue.Value[1]+1)
                {
                    Console.WriteLine(keyValue.Key);
                    counter++;
                }
            }

            if(counter==0)
            {
                Console.WriteLine("space");
            }

            shipCoordinates[1] += 1;
        }
    }
}