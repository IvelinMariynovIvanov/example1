using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03OpinionPoll
{
    class P03OpinionPoll
    {
        static void Main(string[] args)
        {
            List<Person> persList = new List<Person>();
            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string[] line = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                Person a = new Person
                {
                    name = line[0],
                    age = int.Parse(line[1])
                };
                persList.Add(a);
            }
            persList.Where(x => x.age > 30).OrderBy(x => x.name).ToList().ForEach(x => Console.WriteLine(x.name + " - " + x.age));
        }
    }
    public class Person
    {
        public string name = "No name";
        public int age = 1;
    }
}
