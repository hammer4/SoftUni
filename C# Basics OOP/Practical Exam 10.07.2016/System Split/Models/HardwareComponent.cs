using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Split
{
    public class HardwareComponent
    {
        private string name;
        private long maximumCapacity;
        private long maximumMemory;
        private long usedMemory;
        private long usedCapacity;
        private List<SoftwareComponent> softwareComponents;

        protected HardwareComponent(string name, long maximumCapacity, long maximumMemory)
        {
            this.Name = name;
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
            this.UsedCapacity = 0;
            this.UsedMemory = 0;
            this.softwareComponents = new List<SoftwareComponent>();
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

        public virtual long MaximumCapacity
        {
            get
            {
                return this.maximumCapacity;
            }

            protected set
            {
                this.maximumCapacity = value;
            }
        }

        public virtual long MaximumMemory
        {
            get
            {
                return this.maximumMemory;
            }

            protected set
            {
                this.maximumMemory = value;
            }
        }

        public long UsedCapacity
        {
            get
            {
                return this.usedCapacity;
            }

            set
            {
                this.usedCapacity = value;
            }
        }

        public long UsedMemory
        {
            get
            {
                return this.usedMemory;
            }

            set
            {
                this.usedMemory = value;
            }
        }

        public void AddSoftwareComponent(SoftwareComponent software)
        {
            this.softwareComponents.Add(software);
        }

        public void RemoveSoftwareComponent(SoftwareComponent software)
        {
            this.softwareComponents.Remove(software);
        }

        public List<SoftwareComponent> SeeSoftware()
        {
            return this.softwareComponents;
        }
    }
}
