using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04CompanyRoster
{
    class P04CompanyRoster
    {
        static void Main(string[] args)
        {
            List<Employee> employes = new List<Employee>();
            int countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {
                string[] line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Employee employee = new Employee
                {
                    name = line[0].Trim(),
                    salary = decimal.Parse(line[1].Trim()),
                    position = line[2].Trim(),
                    department = line[3].Trim(),                    
                };
                if (line.Length > 4)
                {

                    if (int.TryParse(line[4], out employee.age))
                    {

                    }
                    else
                    {
                        employee.age = -1;
                        employee.email = line[4].Trim();
                    }
                }
                if (line.Length > 5)
                {
                    employee.age = int.Parse(line[5]);
                }
                employes.Add(employee);

            }
            var highSalaryDep = employes.GroupBy(x => x.department).Select(x => new
            {
                Department = x.Key,
                AverageSalary = x.Average(y => y.salary),
                Employes = x.OrderByDescending(y => y.salary)
            }).OrderByDescending(x => x.AverageSalary).FirstOrDefault();
            Console.WriteLine($"Highest Average Salary: {highSalaryDep.Department}");

            foreach (var something in highSalaryDep.Employes)
            {
                Console.WriteLine($"{something.name} {something.salary:f2} {something.email} {something.age}");
            }
        }
    }
    public class Employee
    {
        public string name;
        public string position;
        public string email = "n/a";
        public string department;
        public int age = -1;
        public decimal salary;
    }
}
