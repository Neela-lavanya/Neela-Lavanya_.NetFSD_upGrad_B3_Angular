//problem 3: Employee Performance Evaluator using Tuples and Pattern Matching
//Requirements
//1.	Accept the following inputs from the user:
//o Employee Name
//o	Monthly Sales Amount
//o	Customer Feedback Rating (1–5)
//2.	Create a method that returns Sales Amount and Rating together using a Tuple.
//3.Use pattern matching with switch expression or switch statement to categorize performance:
//o High Performer → Sales ≥ 100000 AND Rating ≥ 4
//o	Average Performer → Sales ≥ 50000 AND Rating ≥ 3
//o	Needs Improvement → All other cases
//4.	Display:
//o Employee Name
//o	Sales Amount
//o	Rating
//o	Performance Category

using System;

namespace EmployeePerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // inputs
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Monthly Sales Amount: ");
                double sales = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Customer Rating (1-5): ");
                int rating = Convert.ToInt32(Console.ReadLine());

                // Validate rating
                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine(" Invalid rating! Must be between 1 and 5.");
                    return;
                }

                // Call method returning Tuple
                var result = GetPerformanceData(sales, rating);

                // Pattern Matching using switch expression
                string performance = result switch
                {
                    ( >= 100000, >= 4) => "High Performer",
                    ( >= 50000, >= 3) => "Average Performer",
                    _ => "Needs Improvement"
                };

                // Display Output
                Console.WriteLine("\n===== Employee Performance =====");
                Console.WriteLine("Employee Name : " + name);
                Console.WriteLine("Sales Amount  : " + result.sales);
                Console.WriteLine("Rating        : " + result.rating);
                Console.WriteLine("Performance   : " + performance);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }
        }

        // Method returning Tuple
        static (double sales, int rating) GetPerformanceData(double sales, int rating)
        {
            return (sales, rating);
        }
    }
}