using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Hardwares
{
    class HeavyHardware : Hardware
    {
        private const int CapacityMultiplier = 2;
        private const int MemoryDivisor = 4;

        public HeavyHardware(string name, string type, int maxCapacity, int maxMemory) : base(name, type, maxCapacity, maxMemory)
        {
        }

        public override int MaxCapacity
        {
            get
            {
                return base.MaxCapacity;
            }
            protected set
            {
                base.MaxCapacity = value * CapacityMultiplier;
            }
        }

        public override int MaxMemory
        {
            get
            {
                return base.MaxMemory;
            }
            protected set
            {
                base.MaxMemory = value - (value / MemoryDivisor);
            }
        }
    }
}
