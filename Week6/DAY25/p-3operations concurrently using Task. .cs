
//Requirements
//1.	Create three methods:
//a.GenerateSalesReport()
//b.GenerateInventoryReport()
//c.GenerateCustomerReport()
//2.Each method should simulate processing time using Thread.Sleep() or Task.Delay().
//3.Execute all three operations concurrently using Task.
//4.Display a message when each report starts and when it finishes.
//5.	Display a final message once all reports are completed.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting report generation...\n");

            // Run tasks concurrently
            Task t1 = Task.Run(() => GenerateSalesReport());
            Task t2 = Task.Run(() => GenerateInventoryReport());
            Task t3 = Task.Run(() => GenerateCustomerReport());

            // Wait for all tasks to complete
            Task.WaitAll(t1, t2, t3);

            Console.WriteLine("\nAll reports generated successfully!");
            Console.ReadLine();
        }

        static void GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Started...");
            Thread.Sleep(3000); // simulate work
            Console.WriteLine("Sales Report Completed!");
        }

        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started...");
            Thread.Sleep(2000); // simulate work
            Console.WriteLine("Inventory Report Completed!");
        }

        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started...");
            Thread.Sleep(2500); // simulate work
            Console.WriteLine("Customer Report Completed!");
        }
    }
}