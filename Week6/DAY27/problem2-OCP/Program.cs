using ConsoleApp12;
using System;
using System.Collections.Generic;

// Entity
class Program
{
    static void Main()
    {
        var calc = new DiscountCalculator();
        Console.WriteLine(calc.GetFinalPrice(1000, new VipCustomerDiscount()));
    }
}