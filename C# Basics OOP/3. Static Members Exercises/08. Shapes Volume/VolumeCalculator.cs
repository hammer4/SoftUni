using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Shapes_Volume
{
    public class VolumeCalculator
    {
        public static double CubeVolume(Cube cube)
        {
            return Math.Pow(cube.sizeLegth, 3);
        }

        public static double TriangularPrismVolume(TriangularPrism prism)
        {
            return (prism.baseSide * prism.height * prism.length) / 2;
        }

        public static double CylinderVolume(Cylinder cylinder)
        {
            return Math.PI * Math.Pow(cylinder.radius, 2) * cylinder.height;
        }
    }
}
