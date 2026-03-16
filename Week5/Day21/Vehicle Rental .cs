
//Level - 2 Problem 2: Vehicle Rental System

//1.Create a base class Vehicle with properties Brand and RentalRatePerDay.
//2. Create derived classes Car and Bike.
//3. Override CalculateRental(int days) method.
//4. Car adds insurance charge of 500 per rental.
//5. Bike offers 5% discount on total rental.
using ConsoleApp11;

//Sample Input: 
//Car RentalRatePerDay = 2000, Days = 3
//Sample Output: 
//Total Rental = 6500


using System;

namespace ConsoleApp11
{
    class Vehicle
    {
        private string brand;
        private double rentalRatePerDay;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Rate cannot be negative");
                else
                    rentalRatePerDay = value;
            }
        }

        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid days");
                return 0;
            }

            return rentalRatePerDay * days;
        }
    }

    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days + 500;
            return total;
        }
    }

    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            total = total - (total * 0.05);
            return total;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter Vehicle Type (1-Car, 2-Bike): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Brand: ");
            string brand = Console.ReadLine();

            Console.WriteLine("Enter Rental Rate Per Day: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Number of Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle;

            if (choice == 1)
                vehicle = new Car();
            else
                vehicle = new Bike();

            vehicle.Brand = brand;
            vehicle.RentalRatePerDay = rate;

            double total = vehicle.CalculateRental(days);

            Console.WriteLine("Total Rental = " + total);
        }
    }
}