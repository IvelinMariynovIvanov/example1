using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06PlanckConstant
{
    class P06PlanckConstant
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation.ReducePlanck());
        }
    }
    class Calculation
    {
        static double Planck = 6.62606896e-34;
        static double PI = 3.14159;

        public static double ReducePlanck()
        {
            double reducedPlanck = Planck / (2 * PI);
            return reducedPlanck;
        }
    }
}
