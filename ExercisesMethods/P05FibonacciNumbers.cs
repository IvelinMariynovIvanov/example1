using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05FibonacciNumbers
{
    class P05FibonacciNumbers
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            Fibonacci.GetFibonachiFromRange(startNumber, endNumber);
        }
    }
    public static class Fibonacci
    {
        static List<long> fiboNums = new List<long>() { 0, 1, 1 };
        static List<long> numsForShow = new List<long>();
        static Fibonacci()
        {
            for (int i = 3; i < 100; i++)
            {
                long nextFibo = fiboNums[i - 1] + fiboNums[i - 2];
                fiboNums.Add(nextFibo);
            }
        }

        public static void GetFibonachiFromRange(int startNumber, int endNumber)
        {
            List<long> numsForShow = new List<long>();
            for (int i = startNumber; i < endNumber; i++)
            {
                numsForShow.Add(fiboNums[i]);
            }
            Console.WriteLine(string.Join(", ", numsForShow));
        }
    }
}
