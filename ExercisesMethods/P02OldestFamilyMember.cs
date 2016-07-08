using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P02OldestFamilyMember
{
    class P02OldestFamilyMember
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();
            int numOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfLines; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }
            family.GetOldestMember();

        }
    }
    public class Family
    {
        List<Person> people = new List<Person>();

        public void AddMember(Person person)
        {
            people.Add(person);
        }
        public void GetOldestMember()
        {
            Person oldestPerson = new Person();
            foreach (Person person in people)
            {
                if (person.age > oldestPerson.age)
                {
                    oldestPerson = person;
                }
            }
            Console.WriteLine($"{oldestPerson.name} {oldestPerson.age}");
        }

    }
    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public Person() : this(string.Empty, int.MinValue)
        {

        }
    }
}
