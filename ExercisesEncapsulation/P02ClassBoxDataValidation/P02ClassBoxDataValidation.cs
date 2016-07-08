using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P02ClassBoxDataValidation
{
    class P02ClassBoxDataValidation
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }

        }
    }
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value > 0.0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value > 0.0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }

            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value > 0.0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }
            }
        }
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
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
