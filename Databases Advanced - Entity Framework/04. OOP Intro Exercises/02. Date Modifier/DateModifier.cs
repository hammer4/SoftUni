using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DateModifier
{
    private DateTime date1;
    private DateTime date2;

    public DateModifier(DateTime date1, DateTime date2)
    {
        this.date1 = date1;
        this.date2 = date2;
    }

    public double DateDifferenceInDays()
    {
        return Math.Abs((date2 - date1).TotalDays);
    }
}
