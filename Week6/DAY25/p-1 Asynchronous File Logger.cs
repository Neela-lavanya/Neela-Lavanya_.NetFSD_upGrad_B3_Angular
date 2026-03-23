//Level - 1 Problem 1: Asynchronous File Logger

using System;
using System.Threading.Tasks;

namespace AsyncLoggerDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started...\n");

            // Different log messages
            Task log1 = WriteLogAsync("logged into the system");
            Task log2 = WriteLogAsync("New order placed with Order ID: 1023");
            Task log3 = WriteLogAsync("Database connection established");
            Task log4 = WriteLogAsync("Payment processed successfully");
          ;

            Console.WriteLine("Main thread is still running...\n");

            await Task.WhenAll(log1, log2, log3, log4);

            Console.WriteLine("\nAll logs completed!");
        }

        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start: {message}");

            await Task.Delay(2000); // simulate delay

            Console.WriteLine($"Done: {message}");
        }
    }
}