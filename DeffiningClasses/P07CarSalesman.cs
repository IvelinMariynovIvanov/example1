using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07CarSalesman
{
    class P07CarSalesman
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int engineLinesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineLinesCount; i++)
            {
                string[] engineLinesStr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = engineLinesStr[0];
                int power = int.Parse(engineLinesStr[1]);
                int displacement;
                string efficiency;

                if (engineLinesStr.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (engineLinesStr.Length == 3)
                {

                    efficiency = engineLinesStr[2];
                    if (int.TryParse(engineLinesStr[2], out displacement))
                    {
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(engine);
                    }
                }
                else if (engineLinesStr.Length == 4)
                {
                    displacement = int.Parse(engineLinesStr[2]);
                    efficiency = engineLinesStr[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
            }

            int carModelsLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < carModelsLines; i++)
            {
                string[] carLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = carLine[0];
                string engine = carLine[1];
                int weight;
                string color;
                Engine thisEngine = engines.Where(x => x.model == engine).Single();
                if (carLine.Length == 2)
                {
                    Car car = new Car(model, thisEngine);
                    cars.Add(car);
                }
                else if (carLine.Length == 3)
                {
                    if (int.TryParse(carLine[2], out weight))
                    {
                        Car car = new Car(model, thisEngine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        color = carLine[2];
                        Car car = new Car(model, thisEngine, color);
                        cars.Add(car);
                    }
                }
                else if (carLine.Length == 4)
                {
                    weight = int.Parse(carLine[2]);
                    color = carLine[3];
                    Car car = new Car(model, thisEngine, weight, color);
                    cars.Add(car);
                }

            }

            foreach (Car car in cars)
            {
                string weight = car.weight.ToString();
                string displacement = car.engine.displacement.ToString();

                if (weight == "-1")
                {
                    weight = "n/a";
                }
                if (displacement == "-1")
                {
                    displacement = "n/a";
                }
                Console.WriteLine($"{car.model}:");
                Console.WriteLine($"  {car.engine.model}:");
                Console.WriteLine($"    Power: {car.engine.power}");
                Console.WriteLine($"    Displacement: {displacement}");
                Console.WriteLine($"    Efficiency: {car.engine.efficinecy}");
                Console.WriteLine($"  Weight: {weight}");
                Console.WriteLine($"  Color: {car.color}");

            }
        }
    }

    public class Car
    {
        public string model;
        public Engine engine;
        public int weight;
        public string color;
        //opt: weight, color;

        public Car(string model, Engine engine) :this(model, engine, -1, "n/a")
        {

        }

        public Car(string model, Engine engine, string color) : this(model, engine, -1, color)
        {

        }
        public Car(string model, Engine engine, int weight) : this(model, engine, weight, "n/a")
        {

        }
        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

    }

    public class Engine
    {
        public string model;
        public int power;
        public int displacement;
        public string efficinecy;

        public Engine(string model, int power) : this (model, power, -1, "n/a")
        {

        }
        public Engine(string model, int power, int displacement) : this(model, power, displacement, "n/a")
        {

        }
        public Engine(string model, int power, string efficinecy) : this(model, power, -1, efficinecy)
        {

        }
        public Engine(string model, int power, int displacement, string efficinecy)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficinecy = efficinecy;
        }

    }
}
