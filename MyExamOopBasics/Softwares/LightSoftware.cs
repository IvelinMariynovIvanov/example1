using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Softwares
{
    public class LightSoftware : Software
    {
        private const int CapacityDivisor = 2;
        private const int MemoryMultiplier = 2;

        public LightSoftware(string name, string type, int capacityConsumption, int memoryConsumption) : base(name, type, capacityConsumption, memoryConsumption)
        {
        }

        public override int CapacityConsumption
        {
            get
            {
                return base.CapacityConsumption;
            }

            protected set
            {
                base.CapacityConsumption = value + (value / CapacityDivisor);
            }
        }

        public override int MemoryConsumption
        {
            get
            {
                return base.MemoryConsumption;
            }

            protected set
            {
                base.MemoryConsumption = value - (value / MemoryMultiplier);
            }
        }
    }
}
