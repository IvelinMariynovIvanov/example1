using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06PrimeChecker
{
    class P06PrimeChecker
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Number isPrimeNumber = new Number(number);
            Console.WriteLine($"{isPrimeNumber.NextPrime()}, {isPrimeNumber.IsPrime().ToString().ToLower()}");
        }
    }
    public class Number
    {
        int number;

        public Number(int number)
        {
            this.number = number;
        }

        public bool IsPrime()
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int NextPrime()
        {
            int nextNumber = this.number + 1;

            while (true)
            {
                bool isPrimeNext = true;

                for (int i = 2; i < nextNumber; i++)
                {
                    if (nextNumber % i == 0)
                    {
                        isPrimeNext = false;
                    }
                }
                if (isPrimeNext)
                {
                    return nextNumber;
                }

                nextNumber++;
            }
        }
    }
}
