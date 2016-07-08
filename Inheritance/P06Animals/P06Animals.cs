using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P06Animals
{
    class P06Animals
    {
        static void Main(string[] args)
        {
            string typeOfClass;
            string pattern = @"([\sa-zA-Z]*)?\s*(-?[0-9]+)?\s*(Female|Male)?";
            Regex regex = new Regex(pattern);
            while ((typeOfClass = Console.ReadLine().Trim()) != "Beast!")
            {
                string animalData = Console.ReadLine().Trim();
                Match matcher = regex.Match(animalData);

                string name = string.Empty;
                int age;
                string gender = string.Empty;

                if (matcher.Groups[1].Success)
                {
                    name = matcher.Groups[1].Value.Trim();
                }

                if (matcher.Groups[2].Success)
                {
                    age = int.Parse(matcher.Groups[2].Value.Trim());
                }
                else
                {
                    age = -1;
                }

                if (matcher.Groups[3].Success)
                {
                    gender = matcher.Groups[3].Value.Trim();
                }

                try
                {
                    switch (typeOfClass)
                    {
                        case "Animal": Animal animal = new Animal(name, age, gender);
                            Console.WriteLine(animal); animal.ProduceSound(); break;
                        case "Cat": Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat); cat.ProduceSound(); break;
                        case "Dog": Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(dog); dog.ProduceSound(); break;
                        case "Frog": Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog); frog.ProduceSound(); break;
                        case "Tomcat": Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat); tomcat.ProduceSound(); break;
                        case "Kitten": Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(kitten); kitten.ProduceSound(); break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException aex)
                {

                    Console.WriteLine(aex.Message);
                    return;
                }
            }
        }
    }
    public class Animal
    {
        protected string name;
        protected int age;
        protected string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                //bool hasDigit = false;
                //for (int i = 0; i < value.Length; i++)
                //{
                //    if (char.IsDigit(value[i]))
                //    {
                //        hasDigit = true;
                //        break;
                //    }
                //}
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                if ((value != "Male" && value != "Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }



        public virtual void ProduceSound()
        {
            Console.WriteLine("Not implemented!");
        }

        public override string ToString()
        {
            string toString = $"{this.GetType().Name}\n{this.Name} {this.Age} {this.Gender}";
            return toString;
        }
    }

    public class Dog : Animal
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("BauBau");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("MiauMiau");
        }
    }

    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Frogggg");
        }
    }

    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age, "Female")
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miau");
        }
    }

    public class Tomcat : Cat
    {

        public Tomcat(string name, int age) : base(name, age, "Male")
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Give me one million b***h");
        }
    }

}
