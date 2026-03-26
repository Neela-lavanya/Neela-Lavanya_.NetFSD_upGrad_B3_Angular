using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * 0.05;
    }
}
