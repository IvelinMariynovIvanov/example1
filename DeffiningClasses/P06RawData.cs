using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06RawData
{
    class P06RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                string[] line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = line[0];
                int engineSpeed = int.Parse(line[1]);
                int enginePower = int.Parse(line[2]);
                int cargoWeight = int.Parse(line[3]);
                string cargoType = line[4];
                Tire[] tires = new Tire[4];

                tires[0] = new Tire(double.Parse(line[5]), int.Parse(line[6]));
                tires[1] = new Tire(double.Parse(line[7]), int.Parse(line[8]));
                tires[2] = new Tire(double.Parse(line[9]), int.Parse(line[10]));
                tires[3] = new Tire(double.Parse(line[11]), int.Parse(line[12]));

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires);
                cars.Add(car);
            }
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(x => x.cargoType == "fragile" && x.tire.Any(y => y.pressure < 1)).ToList().ForEach(x => Console.WriteLine(x.model));
            }
            else
            {
                cars.Where(x => x.cargoType == "flamable" && x.enginePower > 250).ToList().ForEach(x => Console.WriteLine(x.model));
            }
        }
    }
    public class Car
    {
        //<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType>
        //<Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>”
       public string model;
       public int engineSpeed;
       public int enginePower;
       public int cargoWeight;
       public string cargoType;
       public Tire[] tire;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, Tire[] tire)
        {
            this.model = model;
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
            this.tire = tire;
            
        }
    }
    public class Tire
    {
        public int age;
        public double pressure;
        public Tire(double pressure, int age)
        {
            this.age = age;
            this.pressure = pressure;
        }
    }
}
