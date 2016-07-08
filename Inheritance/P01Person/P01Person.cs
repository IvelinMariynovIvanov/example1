using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01Person
{
    class P01Person
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int a = 3;
            a.ToString();
            try
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
    class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length >= 3)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                this.name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Age must be positive!");
                }
            }
        }
        public override string ToString()
        {
            string toString = $"Name: {this.Name}, Age: {this.Age}";

            return toString;
        }
    }
    class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }
        public override int Age
        {
            get
            {
                return base.Age;
            }

            set
            {
                
                if (value >= 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");

                }
                base.Age = value;

            }
        }
    }
}

