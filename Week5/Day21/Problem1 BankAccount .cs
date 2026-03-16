//Level - 1 Problem 1: Bank Account Management System

//Requirements:
//1.Create a BankAccount class with private fields for account number and balance.
//2.Use properties to allow controlled access to account number and balance.
//3.Implement Deposit and Withdraw methods with proper validation.
//4.Prevent withdrawal if balance is insufficient


//Sample Input: 
//Deposit = 5000, Withdraw = 2000
//Sample Output: 
//Current Balance = 3000


using System;

namespace BankApplication
{
    class BankAccount
    {
        // Private Fields
        private string accountNumber;
        private double balance;

        // Property for Account Number
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        // Property for Balance (Read only)
        public double Balance
        {
            get { return balance; }
        }

        // Deposit Method
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount");
            }
            else
            {
                balance = balance + amount;
                Console.WriteLine("Deposited Amount: " + amount);
            }
        }

        // Withdraw Method
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine("Withdrawn Amount: " + amount);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.AccountNumber = "12345";

            account.Deposit(5000);

            account.Withdraw(2000);

            Console.WriteLine("Current Balance = " + account.Balance);

            Console.ReadLine();
        }
    }
}