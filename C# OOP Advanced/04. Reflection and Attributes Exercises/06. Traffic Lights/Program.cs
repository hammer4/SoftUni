using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        TrafficLight[] trafficLights = new TrafficLight[input.Length];

        for (int i=0; i<trafficLights.Length; i++)
        {
            trafficLights[i] = (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[] { input[i] });
        }

        int count = int.Parse(Console.ReadLine());

        for(int i=0; i<count; i++)
        {
            List<string> result = new List<string>();
            foreach(var trafficLight in trafficLights)
            {
                trafficLight.Update();
                var field = typeof(TrafficLight).GetField("currentSignal", BindingFlags.NonPublic | BindingFlags.Instance);
                result.Add(field.GetValue(trafficLight).ToString());
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}