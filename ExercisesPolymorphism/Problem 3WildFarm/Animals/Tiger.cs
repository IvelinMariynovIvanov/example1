using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_3WildFarm.Foods;

namespace Problem_3WildFarm.Animals
{
    public class Tiger : Felime
    {
        public Tiger(string type, string name, double weight, string livingRegion) : base(type, name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Vegetable")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }
            this.foodEaten += food.Quantity;

        }

        public override void MakeSount()
        {
            Console.WriteLine("ROAAR!!!");
        }
    }
}
