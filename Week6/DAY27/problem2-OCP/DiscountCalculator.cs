using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class DiscountCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy strategy)
        {
            return amount - strategy.CalculateDiscount(amount);
        }
    }
}
