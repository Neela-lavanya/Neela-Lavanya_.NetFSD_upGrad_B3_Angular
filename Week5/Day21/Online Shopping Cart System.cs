//Level - 2 Problem 1: Online Shopping Cart System
//Requirements:
//1.Create a base class Product with properties Name and Price.
//2. Create derived classes Electronics and Clothing.
//3. Implement a virtual method CalculateDiscount().
//4. Electronics get 5% discount, Clothing gets 15% discount.
//5. Use encapsulation to protect price updates.

using ConsoleApp11;

//Sample Input: Electronics Price = 20000
//Sample Output: Final Price after 5% discount = 19000

using System;

namespace ConsoleApp11 { 
    // Base Class
    class Product
    {
        private string name;
        private double price;

        // Name Property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Price Property with validation
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative");
                }
                else
                {
                    price = value;
                }
            }
        }

        // Virtual Method
        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    // Electronics Class
    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05); // 5% discount
        }
    }

    // Clothing Class
    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15); // 15% discount
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Product Type (1-Electronics, 2-Clothing): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Product product;

            if (choice == 1)
            {
                product = new Electronics();
            }
            else
            {
                product = new Clothing();
            }

            product.Name = name;
            product.Price = price;

            double finalPrice = product.CalculateDiscount();

            Console.WriteLine("Final Price after discount = " + finalPrice);

            Console.ReadLine();
        }
    }
}