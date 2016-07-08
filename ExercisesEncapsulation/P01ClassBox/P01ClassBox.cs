using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P01ClassBox
{
    class P01ClassBox
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
    }
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double SurfaceArea()
        {
            double surfaceArea = (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);
            return surfaceArea;
        }
        public double LateralArea()
        {
            double lateralArea = (2 * this.length * this.height) + (2 * this.width * this.height);
            return lateralArea;
        }
        public double Volume()
        {
            double volume = this.length * this.width * this.height;
            return volume;
        }
    }
}
