using System;

namespace ConsoleApp11
{
    class Employee
    {
        private string _fullName = "";
        private int _age;
        private decimal _salary;
        private readonly string _employeeId = "";

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be empty");

                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18 || value > 80)
                    throw new ArgumentException("Age must be between 18 and 80");

                _age = value;
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            private set
            {
                if (value < 1000)
                    throw new ArgumentException("Salary must be at least 1000");

                _salary = value;
            }
        }

        public string EmployeeId
        {
            get { return _employeeId; }
        }

        public Employee(string fullName, decimal salary, int age, string? employeeId = null)
        {
            FullName = fullName;
            Age = age;
            Salary = salary;

            _employeeId = employeeId ?? GenerateEmployeeId();
        }

        private string GenerateEmployeeId()
        {
            return "E" + new Random().Next(1000, 9999);
        }

        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
                throw new ArgumentException("Raise must be between 1 and 30 percent");

            decimal increase = Salary * (percentage / 100);
            Salary += increase;

            Console.WriteLine("Salary increased successfully");
        }

        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Penalty must be greater than 0");

            if (Salary - amount < 1000)
                return false;

            Salary -= amount;
            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Marko Horvat", 4500m, 35);

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Name: " + emp.FullName);
            Console.WriteLine("Age: " + emp.Age);
            Console.WriteLine("Salary: " + emp.Salary);

            emp.GiveRaise(15);

            Console.WriteLine("Salary after raise: " + emp.Salary);

            bool result = emp.DeductPenalty(500);

            if (result)
                Console.WriteLine("Penalty deducted");
            else
                Console.WriteLine("Penalty rejected");

            Console.WriteLine("Final Salary: " + emp.Salary);
        }
    }
}