using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_3WildFarm.Foods;

namespace Problem_3WildFarm.Animals
{
    public abstract class Animal
    {
        protected string name;
        protected string type;
        protected double weight;
        protected int foodEaten;

        public Animal(string type, string name, double weight)
        {
            this.Type = type;
            this.Name = name;
            this.Weight = weight;
        }


        public abstract void MakeSount();

        public abstract void Eat(Food food);

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

        public double Weight
        {
            get
            {
                return this.weight;
            }
            protected set
            {
                this.weight = value;
            }
        }
    }
}
