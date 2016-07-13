using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Split
{
    public class ExpressSoftwareComponent : SoftwareComponent
    {
        private string type;

        public ExpressSoftwareComponent(string name, long capacityConsumption, long memoryConsumption)
            :base(name, capacityConsumption, memoryConsumption)
        {
            this.MemoryConsumption = memoryConsumption;
        }

        public override long MemoryConsumption
        {
            get
            {
                return base.MemoryConsumption;
            }

            protected set
            {
                base.MemoryConsumption =value * 2;
            }
        }
    }
}
