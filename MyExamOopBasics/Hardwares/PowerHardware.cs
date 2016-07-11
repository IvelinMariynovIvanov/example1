using StartUp.Softwares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Hardwares
{
    public class PowerHardware : Hardware
    {

        public PowerHardware(string name, string type, int maxCapacity, int maxMemory) 
            : base(name, type, maxCapacity, maxMemory)
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
                base.MaxCapacity = value - ((value * 3) / 4); 
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
                base.MaxMemory = value + ((value * 3) / 4);
            }
        }


    }
}
