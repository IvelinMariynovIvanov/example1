using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03Mankind
{
    class P03Mankind
    {
        static void Main(string[] args)
        {
            string[] studentLine = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            string studentFirstName = studentLine[0];
            string studentLastName = studentLine[1];
            string studentFacultyNumber = studentLine[2];

            string[] workerLine = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            string workerFirstName = workerLine[0];
            string workerLastName = workerLine[1];
            decimal weeklySalary = decimal.Parse(workerLine[2]);
            double workingHours = double.Parse(workerLine[3]);

            try
            {
                Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
                Worker worker = new Worker(workerFirstName, workerLastName, weeklySalary, workingHours);

                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Faculty number: {student.FacultyNumber}");
                Console.WriteLine();
                Console.WriteLine($"First Name: {worker.FirstName}");
                Console.WriteLine($"Last Name: {worker.LastName}");
                Console.WriteLine($"Week Salary: {worker.WeekSalary:f2}");
                Console.WriteLine($"Hours per day: {worker.WorkingHoursPerDay:f2}");
                Console.WriteLine($"Salary per hour: {worker.SalaryPerHour():f2}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

    public class Worker : Human
    {
        private decimal weekSalary;
        private double workingHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workingHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHoursPerDay = workingHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public double WorkingHoursPerDay
        {
            get
            {
                return this.workingHoursPerDay;
            }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workingHoursPerDay = value;
            }

        }

        public override string LastName
        {
            get
            {
                return base.LastName;
            }

            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                base.LastName = value;
            }
        }

        public decimal SalaryPerHour()
        {
            decimal salaryPerHour = (this.weekSalary / 5m) / (decimal)this.workingHoursPerDay;

            return salaryPerHour;
        }
    }

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            private set
            {
                bool isLetterOrDigit = true;
                string facultyNumber = value;
                for (int i = 0; i < facultyNumber.Length; i++)
                {
                    if (!char.IsLetterOrDigit(facultyNumber[i]))
                    {
                        isLetterOrDigit = false;
                        break;
                    }
                }
                if (value.Length < 5 || value.Length > 10 || !isLetterOrDigit)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string FirstName
        {
            get
            {
                return base.FirstName;
            }
            protected set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                base.FirstName = value;
            }
        }

        public override string LastName
        {
            get
            {
                return base.LastName;
            }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                base.LastName = value;
            }
        }
    }

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName
        {
            get
            {
                return this.firstName;
            }
            protected set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                this.firstName = value;
            }
        }

        public virtual string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                this.lastName = value;
            }
        }
    }
}
