using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07BasicMath
{
    class P07BasicMath
    {
        static void Main(string[] args)
        {
            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] numbers = line.Split();

                double firstNumber = double.Parse(numbers[1]);
                double secondNumber = double.Parse(numbers[2]);

                switch (numbers[0])
                {
                    case "Sum": Console.WriteLine($"{MathUtil.Sum(firstNumber, secondNumber):f2}"); break;
                    case "Subtract": Console.WriteLine($"{MathUtil.Subtract(firstNumber, secondNumber):f2}"); break;
                    case "Percentage": Console.WriteLine($"{MathUtil.Persentage(firstNumber, secondNumber):f2}"); break;
                    case "Divide": Console.WriteLine($"{MathUtil.Divide(firstNumber, secondNumber):f2}"); break;
                    case "Multiply": Console.WriteLine($"{MathUtil.Multiply(firstNumber, secondNumber):f2}"); break;
                    default:
                        break;
                }
            }
        }
    }
    class MathUtil
    {
        public static double Sum(double a, double b)
        {
            return a + b;
        }
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        public static double Persentage(double a, double b)
        {
            return (a / 100) * b;
        }
        public static double Divide(double a, double b)
        {
            return a / b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
    }
}
