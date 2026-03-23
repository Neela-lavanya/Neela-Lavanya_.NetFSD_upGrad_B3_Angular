
//Level - 2 Problem 4: Asynchronous Order Processing System
using System;
using System.Threading.Tasks;

namespace OrderProcessingSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Order Processing Started...\n");

            await ProcessOrderAsync();

            Console.WriteLine("\nOrder Processing Completed!");
            Console.ReadLine();
        }

        static async Task ProcessOrderAsync()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
        }

        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying Payment...");
            await Task.Delay(2000); //  delay
            Console.WriteLine("Payment Verified");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking Inventory...");
            await Task.Delay(1500);
            Console.WriteLine("Inventory Available");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming Order...");
            await Task.Delay(1000);
            Console.WriteLine("Order Confirmed");
        }
    }
}