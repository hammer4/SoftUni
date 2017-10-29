using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, decimal price)
        : base(author, title, price)
    {
        this.Price *= 1.3m;
    }

}
