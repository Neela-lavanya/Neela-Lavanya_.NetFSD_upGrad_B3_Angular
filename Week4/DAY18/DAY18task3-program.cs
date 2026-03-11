using System;

namespace ConsoleApp35
{
    internal class Program
    {
        static double CalculateBonus(double salary, int experience)
        {
            double bonusPercentage;

            if (experience < 2)
            {
                bonusPercentage = 0.05;
            }
            else if (experience >= 2 && experience <= 5)
            {
                bonusPercentage = 0.10;
            }
            else
            {
                bonusPercentage = 0.15;
            }

            double bonus = salary * bonusPercentage;
            return bonus;
        }

        static void Main(string[] args)
        {
            string name;
            double salary;
            int experience;
            double bonus;
            double finalSalary;

            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter Salary: ");
            salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Experience (years): ");
            experience = int.Parse(Console.ReadLine());

            bonus = CalculateBonus(salary, experience);

            
            finalSalary = bonus > 0 ? salary + bonus : salary;

            Console.WriteLine("****** Employee Details ******");
            Console.WriteLine($"Employee: {name}");
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine($"Final Salary: {finalSalary}");

            Console.ReadLine();
        }
    }
}