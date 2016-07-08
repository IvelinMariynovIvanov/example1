using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03LastDigitName
{
    class P03LastDigitName
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Number numberToString = new Number(number);
            numberToString.LastDigitToString();
        }
    }
    public class Number
    {
        int number;

        public Number(int number)
        {
            this.number = number;
        }

        public void LastDigitToString()
        {
            char digit = number.ToString().ToCharArray().Reverse().Take(1).Single();

            switch (digit)
            {
                case '0': Console.WriteLine("zero"); break;
                case '1': Console.WriteLine("one"); break;
                case '2': Console.WriteLine("two"); break;
                case '3': Console.WriteLine("three"); break;
                case '4': Console.WriteLine("four"); break;
                case '5': Console.WriteLine("five"); break;
                case '6': Console.WriteLine("six"); break;
                case '7': Console.WriteLine("seven"); break;
                case '8': Console.WriteLine("eight"); break;
                case '9': Console.WriteLine("nine"); break;
                default:
                    break;
            }
        }
    }
}
