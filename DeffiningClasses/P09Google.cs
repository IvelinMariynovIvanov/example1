using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09Google
{
    class P09Google
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] personInfo = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                bool containsPerson = false;

                foreach (Person person in persons)
                {
                    if (person.name == name)
                    {
                        containsPerson = true;
                        break;
                    }
                }
                if (!containsPerson)
                {
                    Person person = new Person(name);
                    persons.Add(person);
                }

                if (personInfo[1] == "company")
                {
                    string companyName = personInfo[2];
                    string department = personInfo[3];
                    string salary = personInfo[4];

                    Company company = new Company(companyName, department, salary);
                    foreach (Person person in persons)
                    {
                        if (person.name == name)
                        {
                            person.AddCompany(company);
                            break;
                        }
                    }
                }
                else if (personInfo[1] == "car")
                {
                    string carModel = personInfo[2];
                    string carSpeed = personInfo[3];

                    Car car = new Car(carModel, carSpeed);
                    foreach (Person person in persons)
                    {
                        if (person.name == name)
                        {
                            person.AddCar(car);
                            break;
                        }
                    }
                }
                else if (personInfo[1] == "pokemon")
                {
                    string pokemonName = personInfo[2];
                    string pokemonType = personInfo[3];

                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                    foreach (Person person in persons)
                    {
                        if (person.name == name)
                        {
                            person.AddPokemon(pokemon);
                            break;
                        }
                    }
                }
                else if (personInfo[1] == "parents")
                {
                    string parentName = personInfo[2];
                    string parentBirthday = personInfo[3];

                    Parent parent = new Parent(parentName, parentBirthday);
                    foreach (Person person in persons)
                    {
                        if (person.name == name)
                        {
                            person.AddParent(parent);
                            break;
                        }
                    }
                }
                else if (personInfo[1] == "children")
                {
                    string childName = personInfo[2];
                    string childBirthDay = personInfo[3];

                    Child child = new Child(childName, childBirthDay);
                    foreach (Person person in persons)
                    {
                        if (person.name == name)
                        {
                            person.AddChild(child);
                            break;
                        }
                    }
                }

            }
            string searchPerson = Console.ReadLine();
            foreach (Person person in persons)
            {
                if (person.name == searchPerson)
                {
                    Console.WriteLine(person.name);
                    Console.WriteLine($"Company:");
                    if (person.company != null)
                    {
                        Console.WriteLine($"{person.company.name} {person.company.department} {person.company.salary:f2}");
                    }
                    Console.WriteLine($"Car:");
                    if (person.car != null)
                    {
                        Console.WriteLine($"{person.car.model} {person.car.speed}");
                    }
                    Console.WriteLine($"Pokemon:");
                    foreach (Pokemon pokemon in person.pokemons)
                    {
                        Console.WriteLine($"{pokemon.name} {pokemon.type}");
                    }
                    Console.WriteLine($"Parents:");
                    foreach (Parent parent in person.parents)
                    {
                        Console.WriteLine($"{parent.name} {parent.birthday}");
                    }
                    Console.WriteLine($"Children:");
                    foreach (Child child in person.children)
                    {
                        Console.WriteLine($"{child.name} {child.birthday}");
                    }
                }
            }
        }
    }

    public class Person
    {
        public Person(string name)
        {
            this.name = name;
        }
        public void AddCompany(Company company)
        {
            this.company = company;
        }
        public void AddCar(Car car)
        {
            this.car = car;
        }
        public void AddParent(Parent parent)
        {
            this.parents.Add(parent);
        }
        public void AddChild(Child child)
        {
            this.children.Add(child);
        }
        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public string name;
        public Company company;
        public Car car;
        public List<Parent> parents = new List<Parent>();
        public List<Child> children = new List<Child>();
        public List<Pokemon> pokemons = new List<Pokemon>();

    }
    public class Company
    {
        public Company(string name, string department, string salary)
        {
            this.name = name;
            this.department = department;
            this.salary = decimal.Parse(salary);
        }
        public string name;
        public string department;
        public decimal salary;
    }
    public class Pokemon
    {
        public Pokemon(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
        public string name;
        public string type;
    }
    public class Parent
    {
        public Parent(string name, string birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
        public string name;
        public string birthday;
    }
    public class Child
    {
        public Child(string name, string birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
        public string name;
        public string birthday;
    }
    public class Car
    {
        public Car(string model, string speed)
        {
            this.model = model;
            this.speed = speed;
        }
        public string model;
        public string speed;
    }
}
