using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08Car
{
    class P08Car
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            int speed = int.Parse(line[0]);
            double fuel = double.Parse(line[1]);
            double fuelEconomy = double.Parse(line[2]);

            Car car = new Car(speed, fuel, fuelEconomy);

            string nextLine;
            while ((nextLine = Console.ReadLine()) != "END")
            {
                string[] commandInfo = nextLine.Split();
                if (commandInfo[0] == "Travel")
                {
                    int distance = int.Parse(commandInfo[1]);
                    car.Travel(distance);
                }
                else if (commandInfo[0] == "Refuel")
                {
                    double refuel = double.Parse(commandInfo[1]);
                    car.Refuel(refuel);
                }
                else if (commandInfo[0] == "Distance")
                {
                    car.Distance();
                }
                else if (commandInfo[0] == "Time")
                {
                    car.Time();
                }
                else if (commandInfo[0] == "Fuel")
                {
                    car.Fuel();
                }
            }
        }
    }
    public class Car
    {
        public int driveTimeMinutes;
        public double distanceTraveled;
        public int speed;
        public double fuel;
        public double fuelEconomy;

        public Car(int speed, double fuel, double fuelEconomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEconomy = fuelEconomy;
        }

        public void Travel(int distance)
        {
            this.distanceTraveled += distance;
            if (fuel - (fuelEconomy / 100 * distanceTraveled) < 0)
            {
                distanceTraveled = (fuel / fuelEconomy) * 100;
            }
        }
        public void Refuel(double fuelLitters)
        {
            this.fuel += fuelLitters;
        }



        public void Distance()
        {
            Console.WriteLine($"Total distance: {distanceTraveled:f1} kilometers");
        }
        public void Time()
        {
            driveTimeMinutes = ((int)distanceTraveled * 60) / speed;
            int hours = driveTimeMinutes / 60;
            int minutes = driveTimeMinutes % 60;
            Console.WriteLine($"Total time: {hours} hours and {minutes} minutes");
        }
        public void Fuel()
        {
            this.fuel -= fuelEconomy / 100 * distanceTraveled;
            if (fuel < 0.0)
            {
                distanceTraveled = fuel * fuelEconomy / 100;
                fuel = 0.0;
                 
            }
            Console.WriteLine($"Fuel left: {fuel:f1} liters");
        }
    }
}
