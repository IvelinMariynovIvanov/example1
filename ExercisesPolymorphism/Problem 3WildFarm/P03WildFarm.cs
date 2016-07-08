using Problem_3WildFarm.Animals;
using Problem_3WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Problem_3WildFarm
{
    class P03WildFarm
    {
        static void Main(string[] args)
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] animalData = inputLine.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string[] foodData = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                string animalType = animalData[0];
                string animalName = animalData[1];
                double animalWeight = double.Parse(animalData[2]);
                string region = animalData[3];
                string catBreed = string.Empty;

                string foodType = foodData[0];
                int quantity = int.Parse(foodData[1]);


                if (animalData.Length > 4)
                {
                    catBreed = animalData[4];
                }

                if (animalType == "Cat")
                {
                    Animal animal = new Cat(animalType, animalName, animalWeight, region, catBreed);
                    animal.MakeSount();
                    try
                    {
                        Food food = MakeFood(foodType, quantity);
                        animal.Eat(food);

                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    Console.WriteLine(animal);
                }
                else if (animalType == "Mouse")
                {
                    Animal animal = new Mouse(animalType, animalName, animalWeight, region);
                    animal.MakeSount();
                    try
                    {
                        Food food = MakeFood(foodType, quantity);
                        animal.Eat(food);

                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    Console.WriteLine(animal);
                }
                else if (animalType == "Tiger")
                {
                    Animal animal = new Tiger(animalType, animalName, animalWeight, region);
                    animal.MakeSount();
                    try
                    {
                        Food food = MakeFood(foodType, quantity);
                        animal.Eat(food);

                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    Console.WriteLine(animal);
                }
                else if (animalType == "Zebra")
                {
                    Animal animal = new Zebra(animalType, animalName, animalWeight, region);
                    animal.MakeSount();
                    try
                    {
                        Food food = MakeFood(foodType, quantity);
                        animal.Eat(food);

                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    Console.WriteLine(animal);
                }

            }
        }

        public static Food MakeFood(string foodType, int quantity)
        {
            if (foodType == "Vegetable")
            {
                Food food = new Vegetable(quantity);
                return food;
            }
            else
            {
                Food food = new Meat(quantity);
                return food;
            }
        }
    }
}
