using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04ShoppingSpree
{
    class P04ShoppingSpree
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            
            string[] peopleAndMoney = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleAndMoney.Length; i++)
            {
                string[] personAndMoney = peopleAndMoney[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = personAndMoney[0];
                decimal money = decimal.Parse(personAndMoney[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(name, person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

            }

            string[] allProductsAndPrices = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < allProductsAndPrices.Length; i++)
            {
                string[] productAndPrice = allProductsAndPrices[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = productAndPrice[0];
                decimal price = decimal.Parse(productAndPrice[1]);

                Product product = new Product(name, price);
                //Add to dictionary.

                products.Add(name, product);
            }

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                string[] personBuyProduct = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string personName = personBuyProduct[0];
                string productName = personBuyProduct[1];

                if (people.ContainsKey(personName))
                {
                    if (products.ContainsKey(productName))
                    {
                        people[personName].Buy(products[productName]);
                    }
                }
            }
            foreach (Person person in people.Values)
            {
                Console.WriteLine(person.GetNameAndProducts());
            }
        }
    }
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value >= 0)
                {
                    this.money = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Money)} cannot be negative");
                }
            }
        }
        public void Buy(Product product)
        {
            if (product.Price <= this.Money)
            {
                products.Add(product);
                this.Money -= product.Price;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
        public string GetNameAndProducts()
        {
            if (products.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", products.Select(x => x.Name))}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException($"{nameof(Name)} cannot be empty");
                }
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value > 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Price)} cannot be negative");
                }
            }
        }
    }
}
