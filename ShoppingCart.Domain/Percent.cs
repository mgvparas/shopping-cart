using System;

namespace ShoppingCart.Domain
{
    public class Percent
    {
        public Percent(double value)
        {
            DecimalValue = Convert.ToDecimal(value) / 100;
        }

        public decimal DecimalValue { get; private set; }
    }
}