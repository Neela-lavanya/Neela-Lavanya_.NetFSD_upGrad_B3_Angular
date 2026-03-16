//Level - 1 Problem 2: Employee Salary Calculator

//Requirements:
//1.Create a base class Employee with Name and BaseSalary properties.
//2. Create derived classes Manager and Developer.
//3. Override a virtual method CalculateSalary().
//4. Manager gets 20% bonus, Developer gets 10% bonus.
using EmployeeSalaryApp;

//Sample Input: 
//BaseSalary = 50000
//Sample Output: 
//Manager Salary = 60000, Developer Salary = 55000


using System;

namespace EmployeeSalaryApp
{
    // Base Class
    class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        // Virtual Method
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    // Derived Class - Manager
    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20); // 20% bonus
        }
    }

    // Derived Class - Developer
    class Developer : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10); // 10% bonus
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double baseSalary = 50000;

            // Polymorphism using base class reference
            Employee manager = new Manager();
            manager.Name = "Indu";
            manager.BaseSalary = baseSalary;

            Employee developer = new Developer();
            developer.Name = "Lavi";
            developer.BaseSalary = baseSalary;

            Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
            Console.WriteLine("Developer Salary = " + developer.CalculateSalary());

            Console.ReadLine();
        }
    }
}