using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02VehicleExtension
{
    class P02VehicleExtension
    {
        private static Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

        static void Main(string[] args)
        {
            try
            {
                string[] carInfo = Console.ReadLine().Split();
                string typeCar = carInfo[0];
                double carFuel = double.Parse(carInfo[1]);
                double carConsumption = double.Parse(carInfo[2]);
                double carTankCapacity = double.Parse(carInfo[3]);
                Vehicle car = new Car(carFuel, carConsumption, carTankCapacity);

                string[] truckInfo = Console.ReadLine().Split();
                string typeTruck = truckInfo[0];
                double truckFuel = double.Parse(truckInfo[1]);
                double truckConsumption = double.Parse(truckInfo[2]);
                double truckTankCapacity = double.Parse(truckInfo[3]);
                Vehicle truck = new Truck(truckFuel, truckConsumption, truckTankCapacity);

                string[] busInfo = Console.ReadLine().Split();
                string typeBus = busInfo[0];
                double busFuel = double.Parse(busInfo[1]);
                double busConsumption = double.Parse(busInfo[2]);
                double busTankCapacity = double.Parse(busInfo[3]);
                Vehicle bus = new Bus(busFuel, busConsumption, busTankCapacity);

                vehicles.Add(typeCar, car);
                vehicles.Add(typeTruck, truck);
                vehicles.Add(typeBus, bus);

                int numOfCommands = int.Parse(Console.ReadLine());

                for (int i = 0; i < numOfCommands; i++)
                {
                    try
                    {
                        string[] commandInfo = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                        ExecuteCommand(commandInfo);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }

                }

                Console.WriteLine($"Car: {car.GetRemainingFuel():f2}");
                Console.WriteLine($"Truck: {truck.GetRemainingFuel():f2}");
                Console.WriteLine($"Bus: {bus.GetRemainingFuel():f2}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
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
            else if(command == "Refuel")
            {
                vehicles[vehicleType].Refuel(commandValue);
            }
            else
            {
                Bus currentBus = vehicles["Bus"] as Bus;
                currentBus.DriveEmpty(commandValue);
            }
        }
    }
    public abstract class Vehicle
    {
        protected double tankCapacity;

        protected double fuelQuantity;
        protected double fuelConsumption;

        public abstract void Drive(double distanceToTravel);

        public abstract void Refuel(double refuelQuantity);

        public abstract double GetRemainingFuel();
    }

    public class Car : Vehicle
    {
        protected const double CarSummerFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                this.tankCapacity = value;
            }
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
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
            if (tankCapacity < fuelQuantity + refuelQuantity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
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

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
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

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                this.tankCapacity = value;
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

    public class Bus : Vehicle
    {
        protected const double BusWithPeople = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                this.tankCapacity = value;
            }
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
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
                this.fuelConsumption = value;
            }
        }


        public override void Drive(double distanceToTravel)
        {
            double travableKilometers = this.fuelQuantity / (this.fuelConsumption + BusWithPeople);

            if (travableKilometers >= distanceToTravel)
            {
                Console.WriteLine($"Bus travelled {distanceToTravel} km");
                this.fuelQuantity -= distanceToTravel * (this.fuelConsumption + BusWithPeople);
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }

        }

        public void DriveEmpty(double distanceToTravel)
        {
            double travableKilometers = this.fuelQuantity / this.fuelConsumption;

            if (travableKilometers >= distanceToTravel)
            {
                Console.WriteLine($"Bus travelled {distanceToTravel} km");
                this.fuelQuantity -= distanceToTravel * this.fuelConsumption;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }

        }

        public override void Refuel(double refuelQuantity)
        {
            if (tankCapacity < fuelQuantity + refuelQuantity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
            this.fuelQuantity += refuelQuantity;
        }

        public override double GetRemainingFuel()
        {
            return this.fuelQuantity;
        }
    }
}
