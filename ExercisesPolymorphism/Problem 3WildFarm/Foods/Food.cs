using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3WildFarm.Foods
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        protected int quantity;

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            protected set
            {
                this.quantity = value;
            }
        }
    }
}
