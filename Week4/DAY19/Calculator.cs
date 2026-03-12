using System;

class Calculator
{
    // Method for Addition
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method for Subtraction
    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int addition = calc.Add(num1, num2);
        int subtraction = calc.Subtract(num1, num2);

        Console.WriteLine("Addition = " + addition);
        Console.WriteLine("Subtraction = " + subtraction);
    }
}
