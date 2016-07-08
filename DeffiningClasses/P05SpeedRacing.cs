using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05SpeedRacing
{
    class P05SpeedRacing
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numOfRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfRows; i++)
            {
                string[] line = Console.ReadLine().Split();

                string carModel = line[0];
                double fuelAmount = double.Parse(line[1]);
                double fuelCost = double.Parse(line[2]);
                Car currentCar = new Car(carModel, fuelAmount, fuelCost);
                cars.Add(currentCar);
            }
            string driveLine;
            while ((driveLine = Console.ReadLine()) != "End")
            {
                string[] currentDrive = driveLine.Split();
                string carToDrive = currentDrive[1];
                double amountOfKilometers = double.Parse(currentDrive[2]);

                Car car = cars.Where(x => x.model == carToDrive).Single();
                car.Drive(amountOfKilometers);
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.model} {car.fuelAmount:f2} {car.distanceTraveled}");
            }
        }
    }
    public class Car
    {
        public string model;
        public double fuelAmount;
        public double fuelCost;
        public double distanceTraveled;

        public Car(string model, double fuelAmount, double fuelCost)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelCost = fuelCost;
        }

        public void Drive(double amountOfKilometers)
        {
            if (amountOfKilometers <= this.fuelAmount / this.fuelCost)
            {
                this.fuelAmount -= this.fuelCost * amountOfKilometers;
                this.distanceTraveled += amountOfKilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
