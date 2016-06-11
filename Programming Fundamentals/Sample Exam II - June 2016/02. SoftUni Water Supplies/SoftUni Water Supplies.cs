using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUni_Water_Supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int ammountOfWater = int.Parse(Console.ReadLine());
            List<double> bottles = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            int bottleCapacity = int.Parse(Console.ReadLine());

            double remainingWater = ammountOfWater;
            
            if(ammountOfWater % 2 == 0)
            {
                for(int i=0; i<bottles.Count; i++)
                {
                    double neededWater = bottleCapacity - bottles[i];
                    if(remainingWater >= neededWater)
                    {
                        remainingWater -= neededWater;
                    }
                    else
                    {
                        double requiredWater = 0;
                        bottles[i] += remainingWater;
                        
                        for(int j=i; j<bottles.Count; j++)
                        {
                            requiredWater += bottleCapacity - bottles[j];
                        }

                        Console.WriteLine("We need more water!");
                        Console.WriteLine("Bottles left: {0}", bottles.Count - i);
                        Console.Write("With indexes: ");

                        for(int j=i; j<bottles.Count-1; j++)
                        {
                            Console.Write("{0}, ", j);
                        }

                        Console.WriteLine(bottles.Count-1);

                        Console.WriteLine("We need {0} more liters!", requiredWater);
                        return;
                    }
                }
            }
            else
            {
                for(int i=bottles.Count-1; i>=0; i--)
                {
                    double neededWater = bottleCapacity - bottles[i];
                    if (remainingWater >= neededWater)
                    {
                        remainingWater -= neededWater;
                    }
                    else
                    {
                        double requiredWater = 0;
                        bottles[i] += remainingWater;

                        for (int j = i; j >= 0; j--)
                        {
                            requiredWater += bottleCapacity - bottles[j];
                        }

                        Console.WriteLine("We need more water!");
                        Console.WriteLine("Bottles left: {0}", i+1);
                        Console.Write("With indexes: ");

                        for (int j = i; j > 0; j--)
                        {
                            Console.Write("{0}, ", j);
                        }

                        Console.WriteLine(0);

                        Console.WriteLine("We need {0} more liters!", requiredWater);
                        return;
                    }
                }
            }

            Console.WriteLine("Enough water!");
            Console.WriteLine("Water left: {0}l.", remainingWater);
        }
    }
}
