using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01Vehicles
{
    class P01Vehicles
    {
        private static Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

        static void Main(string[] args)
        {

            string[] carInfo = Console.ReadLine().Split();
            string typeCar = carInfo[0];
            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            Vehicle car = new Car(carFuel, carConsumption);

            string[] truckInfo = Console.ReadLine().Split();
            string typeTruck = truckInfo[0];
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            Vehicle truck = new Truck(truckFuel, truckConsumption);

            vehicles.Add(typeCar, car);
            vehicles.Add(typeTruck, truck);

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] commandInfo = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                ExecuteCommand(commandInfo);
            }

            Console.WriteLine($"Car: {car.GetRemainingFuel():f2}");
            Console.WriteLine($"Truck: {truck.GetRemainingFuel():f2}");
        }

        public static void ExecuteCommand(string[] commandInfo)
        {
            string command = commandInfo[0];
            string vehicleType = commandInfo[1];
            double commandValue = double.Parse(commandInfo[2]);

            if (command == "Drive")
            {
                vehicles[vehicleType].Drive(commandValue);
            }
            else
            {
                vehicles[vehicleType].Refuel(commandValue);
            }
        }
    }
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;

        public abstract void Drive(double distanceToTravel);

        public abstract void Refuel(double refuelQuantity);

        public abstract double GetRemainingFuel();
    }

    public class Car : Vehicle
    {
        protected const double CarSummerFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + CarSummerFuelConsumption;
            }
        }

         
        public override void Drive(double distanceToTravel)
        {
            double travableKilometers = this.fuelQuantity / this.fuelConsumption;

            if (travableKilometers >= distanceToTravel)
            {
                Console.WriteLine($"Car travelled {distanceToTravel} km");
                this.fuelQuantity -= distanceToTravel * this.fuelConsumption;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }

        }

        public override void Refuel(double refuelQuantity)
        {
            this.fuelQuantity += refuelQuantity;
        }

        public override double GetRemainingFuel()
        {
            return this.fuelQuantity;
        }
    }

    public class Truck : Vehicle
    {
        protected const double TruckSummerFuelConsumption = 1.6;
        protected const double CrackInTheTank = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + TruckSummerFuelConsumption;
            }
        }


        public override void Drive(double distanceToTravel)
        {
            double travableKilometers = this.fuelQuantity / this.fuelConsumption;

            if (travableKilometers >= distanceToTravel)
            {
                Console.WriteLine($"Truck travelled {distanceToTravel} km");
                this.fuelQuantity -= distanceToTravel * this.fuelConsumption;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double refuelQuantity)
        {
            this.fuelQuantity += refuelQuantity * CrackInTheTank;
        }

        public override double GetRemainingFuel()
        {
            return this.fuelQuantity;
        }
    }
}
