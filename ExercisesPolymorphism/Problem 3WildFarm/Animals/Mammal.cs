using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3WildFarm.Animals
{
    public abstract class Mammal : Animal
    {
        protected string livingRegion;

        public Mammal(string type, string name, double weight, string livingRegion) : base(type, name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get
            {
                return this.livingRegion;
            }
            protected set
            {
                this.livingRegion = value;
            }
        }

        public override string ToString()
        {
            string toString = $"{this.GetType().Name}[{this.name}, {this.weight}, {this.livingRegion}, {this.foodEaten}]";
            return toString;
        }
    }
}
