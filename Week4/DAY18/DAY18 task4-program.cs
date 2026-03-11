using System;

namespace ConsoleApp35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            Console.WriteLine("Enter Number: ");
            number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                sum = sum + i;

                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            Console.WriteLine("*** Number Analysis ***");
            Console.WriteLine($"Even Count: {evenCount}");
            Console.WriteLine($"Odd Count: {oddCount}");
            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }
    }
}