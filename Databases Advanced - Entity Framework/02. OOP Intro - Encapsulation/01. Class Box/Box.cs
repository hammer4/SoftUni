using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box(decimal length, decimal width, decimal height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public decimal SurfaceArea()
    {
        return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
    }

    public decimal LateralSurfaceArea()
    {
        return 2 * this.length * this.height + 2 * this.width * this.height;
    }

    public decimal Volume()
    {
        return this.length * this.width * this.height;
    }
}
