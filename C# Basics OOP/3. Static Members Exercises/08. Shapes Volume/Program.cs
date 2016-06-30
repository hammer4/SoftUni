using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Shapes_Volume
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                switch(tokens[0])
                {
                    case "Cube":
                        Cube cube = new Cube(double.Parse(tokens[1]));
                        Console.WriteLine("{0:F3}", VolumeCalculator.CubeVolume(cube));
                        break;
                    case "Cylinder":
                        Cylinder cylinder = new Cylinder(double.Parse(tokens[1]), double.Parse(tokens[2]));
                        Console.WriteLine("{0:F3}", VolumeCalculator.CylinderVolume(cylinder));
                        break;
                    case "TrianglePrism":
                        TriangularPrism prism = new TriangularPrism(double.Parse(tokens[1]), double.Parse(tokens[2]),
                            double.Parse(tokens[3]));
                        Console.WriteLine("{0:F3}", VolumeCalculator.TriangularPrismVolume(prism));
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
