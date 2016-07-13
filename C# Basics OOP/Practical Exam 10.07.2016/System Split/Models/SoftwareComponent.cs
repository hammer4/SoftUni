using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Split
{
    public class SoftwareComponent
    {
        private string name;
        private long capacityConsumption;
        private long memoryConsumption;

        public SoftwareComponent(string name, long capacityConsumption, long memoryConsumption)
        {
            this.Name = name;
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public virtual long CapacityConsumption
        {
            get
            {
                return this.capacityConsumption;
            }

            protected set
            {
                this.capacityConsumption = value;
            }
        }

        public virtual long MemoryConsumption
        {
            get
            {
                return this.memoryConsumption;
            }

            protected set
            {
                this.memoryConsumption = value;
            }
        }
    }
}
