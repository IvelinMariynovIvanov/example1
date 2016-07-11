using StartUp.Softwares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StartUp.Hardwares
{
    public abstract class Hardware
    {
        private string name;
        private string type;
        private int maxCapacity;
        private int remainingCapacity;
        private int maxMemory;
        private int remainingMemory;
        public Dictionary<string, Software> containingSoftware;

        public Hardware(string name, string type, int maxCapacity, int maxMemory)
        {
            this.Name = name;
            this.Type = type;
            this.MaxCapacity = maxCapacity;
            this.MaxMemory = maxMemory;
            this.containingSoftware = new Dictionary<string, Software>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
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
            protected set
            {
                this.type = value;
            }
        }

        public int RemainingCapacity
        {
            get
            {
                return this.remainingCapacity;
            }
            set
            {
                this.remainingCapacity = value;
            }
        }

        public int RemainingMemory
        {
            get
            {
                return this.remainingMemory;
            }
            set
            {
                this.remainingMemory = value;
            }
        }

        public virtual int MaxCapacity
        {
            get
            {
                return this.maxCapacity;
            }
            protected set
            {
                this.maxCapacity = value;
                this.remainingCapacity = value;
            }
        }

        public virtual int MaxMemory
        {
            get
            {
                return this.maxMemory;
            }
            protected set
            {
                this.maxMemory = value;
                this.remainingMemory = value;
            }
        }

        public void InstallSoftware(Software software)
        {
            containingSoftware.Add(software.Name, software);
        }
    }
}
