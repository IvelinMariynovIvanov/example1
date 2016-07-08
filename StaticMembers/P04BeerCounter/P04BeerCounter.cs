using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04BeerCounter
{
    class P04BeerCounter
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                int[] beersArr = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int beersInStockMain = beersArr[0];
                int beersToDringMain = beersArr[1];

                BeerInStock.BuyBeers(beersInStockMain);
                BeerInStock.DrinkBeers(beersToDringMain);
            }
            Console.WriteLine($"{BeerInStock.BeersInStock} {BeerInStock.DrankBeers}");
        }
    }
    public class BeerInStock
    {
        private static int beersInStock;
        private static int drankBeers;

        public static int BeersInStock
        {
            get
            {
                return beersInStock;
            }
        }
        public static int DrankBeers
        {
            get
            {
                return drankBeers;
            }
        }

        public static void BuyBeers(int beers)
        {
            beersInStock += beers;
        }
        public static void DrinkBeers(int beers)
        {
            if (beersInStock - beers < 0)
            {
                drankBeers += beersInStock - (beersInStock - beersInStock);
                beersInStock = 0;
            }
            else
            {
                beersInStock -= beers;
                drankBeers += beers;
            }
        }

    }
}
