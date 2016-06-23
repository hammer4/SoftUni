using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Raw_Data
{
    public class Cargo
    {
        public string type;
        public int weight;

        public Cargo(string type, int weight)
        {
            this.type = type;
            this.weight = weight;
        }
    }
}
