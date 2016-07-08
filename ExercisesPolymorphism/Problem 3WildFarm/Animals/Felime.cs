using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_3WildFarm.Foods;

namespace Problem_3WildFarm.Animals
{
    public abstract class Felime : Mammal
    {
        public Felime(string type, string name, double weight, string livingRegion) : base(type, name, weight, livingRegion)
        {
        }
    }
}
