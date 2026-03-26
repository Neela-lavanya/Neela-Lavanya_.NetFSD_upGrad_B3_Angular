using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }
}
