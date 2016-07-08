using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AnimalClinic
{
    class P05AnimalClinic
    {
        static void Main(string[] args)
        {
            
            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] petInfo = line.Split();

                string name = petInfo[0];
                string breed = petInfo[1];
                string operation = petInfo[2];
                Animal animal = new Animal(name, breed);
                if (operation == "heal")
                {
                    AnimalClinic.SetHealedAnimal = animal;
                    Console.WriteLine($"Patient {AnimalClinic.PatientID}: [{animal.Name} ({animal.Breed})] has been healed!");
                }
                else
                {
                    AnimalClinic.SetRehabilitatedAnimal = animal;
                    Console.WriteLine($"Patient {AnimalClinic.PatientID}: [{animal.Name} ({animal.Breed})] has been rehabilitated!");
                }
            }
            Console.WriteLine($"Total healed animals: {AnimalClinic.HealedAnimalsCount}");
            Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.RehabilitatedAnimalsCount}");

            string showAnimalsGroup = Console.ReadLine();
            if (showAnimalsGroup == "heal")
            {
                foreach (Animal animal in AnimalClinic.GetHealedAnimals)
                {
                    Console.WriteLine($"{animal.Name} {animal.Breed}");
                }
            }
            else
            {
                foreach (Animal animal in AnimalClinic.GetRehabilitatedAnimals)
                {
                    Console.WriteLine($"{animal.Name} {animal.Breed}");
                }
            }

        }
    }
    public class Animal
    {
        private string name;
        private string breed;

        public Animal(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public string Breed
        {
            get
            {
                return this.breed;
            }
        }
    }
    public class AnimalClinic
    {
        private static int patientID;
        private static int healedAnimalsCount;
        private static int rehabilitatedAnimalsCount;

        private static List<Animal> rehabilitatedAnimals = new List<Animal>();
        private static List<Animal> healedAnimals = new List<Animal>();

        public static List<Animal> GetRehabilitatedAnimals
        {
            get
            {
                return rehabilitatedAnimals;
            }
        }
        public static Animal SetRehabilitatedAnimal
        {
            set
            {
                rehabilitatedAnimals.Add(value);
                patientID++;
                rehabilitatedAnimalsCount++;
            }
        }

        public static List<Animal> GetHealedAnimals
        {
            get
            {
                return healedAnimals;
            }
        }
        public static Animal SetHealedAnimal
        {
            set
            {
                healedAnimals.Add(value);
                patientID++;
                healedAnimalsCount++;
            }
        }
        public static int PatientID
        {
            get
            {
                return patientID;
            }
        }
        public static int HealedAnimalsCount
        {
            get
            {
                return healedAnimalsCount;
            }
        }
        public static int RehabilitatedAnimalsCount
        {
            get
            {
                return rehabilitatedAnimalsCount;
            }
        }
    }
}
