using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04NumberInReversedOrder
{
    class P04NumberInReversedOrder
    {
        static void Main(string[] args)
        {
            decimal decimalNumber = decimal.Parse(Console.ReadLine());
            DecimalNumber DecimalToReverse = new DecimalNumber(decimalNumber);
            DecimalToReverse.ReverseNumber();
        }
    }
    public class DecimalNumber
    {
        decimal decimalNum;
        public DecimalNumber(decimal decimalNum)
        {
            this.decimalNum = decimalNum;
        }

        public void ReverseNumber()
        {
            char[] reversedNumber = decimalNum.ToString().ToCharArray();
            Array.Reverse(reversedNumber);
            Console.WriteLine(string.Join("", reversedNumber));
        }
    }
}
