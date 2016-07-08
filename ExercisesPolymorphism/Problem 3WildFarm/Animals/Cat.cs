using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_3WildFarm.Foods;

namespace Problem_3WildFarm.Animals
{
    public class Cat : Felime
    {
        private string breed;

        public Cat(string type, string name, double weight, string livingRegion, string breed) : base(type, name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get
            {
                return this.breed;
            }
            private set
            {
                this.breed = value;
            }
        }

        public override void Eat(Food food)
        {
            this.foodEaten += food.Quantity;
        }

        public override void MakeSount()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            string toString = $"{this.GetType().Name}[{this.name}, {this.breed}, {this.weight}, {this.livingRegion}, {this.foodEaten}]";
            return toString;
        }        
    }
}
