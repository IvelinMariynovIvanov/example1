using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Softwares
{
    public class ExpressSoftware : Software
    {
        private const int MemoryConsumptionMultiplier = 2;
        public ExpressSoftware(string name, string type, int capacityConsumption, int memoryConsumption) : base(name, type, capacityConsumption, memoryConsumption)
        {
        }

        public override int MemoryConsumption
        {
            get
            {
                return base.MemoryConsumption;
            }
            protected set
            {
                base.MemoryConsumption = value * MemoryConsumptionMultiplier;
            }
        }
    }
}
