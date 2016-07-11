using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Softwares
{
    public abstract class Software
    {
        private string name;
        private string type;
        private int capacityConsumption;
        private int memoryConsumption;

        public Software(string name, string type, int capacityConsumption, int memoryConsumption)
        {
            this.Name = name;
            this.Type = type;
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

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public virtual int CapacityConsumption
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

        public virtual int MemoryConsumption
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
