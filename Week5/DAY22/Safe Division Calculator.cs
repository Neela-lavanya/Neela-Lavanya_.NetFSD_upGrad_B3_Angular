using System;

namespace ConsoleApp11
{
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.Write("Enter Numerator: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Denominator: ");
            int den = Convert.ToInt32(Console.ReadLine());

            calc.Divide(num, den);

            // Program continues execution
            Console.WriteLine("Program is still running...");
        }
    }
}