using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Rectangle_Intersection
{
    public class Rectangle
    {
        public string id;
        public double width;
        public double height;
        public double x;
        public double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }

        public string Intersects(Rectangle rectangle)
        {
            if((rectangle.y >= this.y && rectangle.y - rectangle.height <=this.y && rectangle.x <= this.x && rectangle.x+rectangle.width >= this.x) || 
                (rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x >= this.x && rectangle.x <= this.x + this.width) || 
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) || 
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x >= this.x && rectangle.x <= this.x + this.width))
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}
