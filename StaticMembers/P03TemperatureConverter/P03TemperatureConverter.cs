using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03TemperatureConverter
{
    class P03TemperatureConverter
    {
        static void Main(string[] args)
        {
            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] strTemp = line.Split();
                int temperatureToConvert = int.Parse(strTemp[0]);
                Console.WriteLine(TemperatureConvertor.Convert(temperatureToConvert, strTemp[1]));
            }
        }
    }
    public class TemperatureConvertor
    {
        public static string Convert(int temperature, string unit)
        {
            double temp;
            string convertedTemp = string.Empty;
            if (unit == "Celsius")
            {
                temp = temperature * (9.0 / 5.0) + 32;
                convertedTemp = $"{temp:f2} Fahrenheit";
                return convertedTemp;
            }
            else
            {
                temp = (temperature - 32) * (5.0 / 9.0);
                convertedTemp = $"{temp:f2} Celsius";
                return convertedTemp;
            }
        }
    }
}
