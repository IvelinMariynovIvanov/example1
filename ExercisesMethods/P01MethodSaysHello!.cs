using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P01MethodSaysHello_
{
    class P01MethodSaysHello
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] methods = personType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            if (fields.Length != 1 || methods.Length != 5)
            {
                throw new Exception();
            }

            string personName = Console.ReadLine();
            Person person = new Person(personName);

            Console.WriteLine(person.SayHello());

        }
    }
    public class Person
    {
        public string name;
        public Person(string name)
        {
            this.name = name;
        }

        public string SayHello()
        {
            string message = $"{name} says \"Hello\"!";
            return message;
        }
    }
}
