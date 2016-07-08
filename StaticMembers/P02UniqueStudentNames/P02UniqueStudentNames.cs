using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02UniqueStudentNames
{
    class P02UniqueStudentNames
    {
        static void Main(string[] args)
        {
            string studentName;
            while ((studentName = Console.ReadLine()) != "End")
            {
                Student student = new Student(studentName);
            }
            Console.WriteLine(CountStudents.GetUniqueNames);
        }
    }
    public class Student
    {
        private string name;

        public string Name
        {
            get
            {
                return Name = this.name;
            }
            set
            {
                this.name = Name;
            }

        }
        public Student(string name)
        {
            this.name = name;
            CountStudents.SetUniqueNames = name;
        }
    }
    public static class CountStudents
    {
        private static HashSet<string> uniqueNames = new HashSet<string>();

        public static int GetUniqueNames
        {
            get
            {
                return uniqueNames.Count;
            }
        }
        public static string SetUniqueNames
        {
            set
            {
                uniqueNames.Add(value);
            }
        }
    }
}
