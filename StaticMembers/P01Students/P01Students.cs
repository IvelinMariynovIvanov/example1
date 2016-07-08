using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01Students
{
    class P01Students
    {
        static void Main(string[] args)
        {
            string student;

            while ((student = Console.ReadLine()) != "End")
            {
                Student newStudent = new Student(student);
            }
            Console.WriteLine(Student.studentsCount);
        }
    }
    public class Student
    {
        public static int studentsCount;
        public string name;

        public Student(string name)
        {
            this.name = name;
            studentsCount++;
        }
    }
}
