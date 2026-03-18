
//Level - 2 Problem 1: Bank Withdrawal System with Custom Exception
//Requirements:
//1.Create a class BankAccount with a private field balance.
//2.	Create a method Withdraw(double amount).
//3.	Create a custom exception class InsufficientBalanceException.
//4.Throw the custom exception if the withdrawal amount exceeds the balance.
//5.	Handle the exception in the main program using try-catch.
//6.Ensure proper cleanup using a finally block.



using System;

namespace ConsoleApp11
{
    // Custom Exception Class
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // BankAccount Class
    public class BankAccount
    {
        private double balance;

        // Constructor
        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        // Withdraw Method
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdrawal Successful!");
                Console.WriteLine("Remaining Balance: " + balance);
            }
        }
    }

    // Main Class
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Balance: ");
                double balance = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Withdraw Amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                BankAccount account = new BankAccount(balance);
                account.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers");
            }
            finally
            {
                Console.WriteLine("Transaction Completed.");
            }
        }
    }
}